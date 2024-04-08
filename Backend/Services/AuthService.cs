using Backend.Contracts.Auth;
using Backend.Services.Interfaces;
using System.Security.Claims;

namespace Backend.Services;

public class AuthService : IAuthService
{
    private static readonly TimeSpan _accessTokenLife = TimeSpan.FromHours(1);
    private static readonly TimeSpan _refreshTokenLife = TimeSpan.FromDays(90);

    private readonly JwtHelper _jwtHelper;
    private readonly AppDbContext _context;
    private readonly HttpContextService _httpContentService;

    public AuthService(
        JwtHelper jwtHelper,
        AppDbContext dbContext,
        HttpContextService httpContentService)
    {
        _jwtHelper = jwtHelper;
        _context = dbContext;
        _httpContentService = httpContentService;
    }

    /// <summary>
    /// JWT login  <br/>
    ///  - accessToken life - 1 hour <br/>
    ///  - refreshToken life - 90 days
    /// </summary>
    /// <returns></returns>
    public async Task<LoginResponseDto> Login(LoginRequestDto request)
    {
        LoginResponseDto response = new();

        // Query
        var customer = await _context.Customers
            .Where(c => c.Account == request.Account)
            .FirstOrDefaultAsync();

        if (customer is null)
        {
            throw new AppException(CommonErrorCode.NotFound, "Account not found");
        }

        // JWT login
        (response.AccessToken, response.RefreshToken) = JWTLogin(customer);

        await _context.SaveChangesAsync();

        return response;
    }

    private (string, string) JWTLogin(Customer customer)
    {
        var now = DateTime.Now;

        // Token init
        var accessToken = GenerateAccessToken(customer);
        var refreshToken = _jwtHelper.GenerateRefreshToken();

        // Save refresh token
        customer.RefreshToken = refreshToken;
        customer.RefreshTokenExpireAt = now.Add(_refreshTokenLife);

        // Response
        var response = new LoginResponseDto()
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
        };

        return (accessToken, refreshToken);
    }

    public async Task<RefreshTokenResponseDto> Refresh(RefreshTokenRequestDto request)
    {
        RefreshTokenResponseDto response = new();
        var now = DateTime.Now;

        // Query
        var customer = await _context.Customers
            .Where(c => c.RefreshToken == request.RefreshToken)
            .FirstOrDefaultAsync();

        if (customer is null)
        {
            throw new AppException(CommonErrorCode.NotFound, "Refresh token not found");
        }

        if (customer.RefreshTokenExpireAt.IsBefore(now))
        {
            throw new AppException(CommonErrorCode.Unauthorized, "Refresh token expired");
        }

        // Refresh the access token
        response.AccessToken = GenerateAccessToken(customer);

        return response;
    }

    private string GenerateAccessToken(Customer customer)
    {
        Claim[] claims = [
            new Claim(ClaimTypes.NameIdentifier, customer.Id.ToString()),
        ];

        return _jwtHelper.GenerateAccessToken(claims, _accessTokenLife);
    }

    // Logout
    public async Task Logout()
    {
        // Get current user id
        var userId = _httpContentService.GetCurrentUserId();

        // Query
        var customer = await _context.Customers
            .Where(c => c.Id == userId)
            .FirstOrDefaultAsync();

        if (customer is null)
        {
            throw new AppException(CommonErrorCode.NotFound, "Customer not found");
        }

        await RevokeRefreshToken(customer);
    }

    // Revoke refresh token
    private async Task RevokeRefreshToken(Customer customer)
    {
        // This method will revoke the refresh token,
        // but not the access token

        // Revoke
        customer.RefreshToken = null;
        customer.RefreshTokenExpireAt = null;

        // Save
        await _context.SaveChangesAsync();
    }
}
