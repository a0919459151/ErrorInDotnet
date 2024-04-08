using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Core.Helpers;

public class HttpContextService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpContextService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    // CookieLogin
    public async Task CookieLogin(Admin admin, bool isPersistent)
    {
        var httpContext = _httpContextAccessor.HttpContext ?? throw new ServerErrorException("HttpContext not found");

        List<Claim> claims = [
            new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()),
            new Claim(ClaimTypes.Name, admin.Account),
        ];

        var claimsIdentity = new ClaimsIdentity(
            claims,
            CookieAuthenticationDefaults.AuthenticationScheme);

        DateTimeOffset dateTimeOffset = DateTimeOffset.Now.AddMonths(3);

        var authProperties = new AuthenticationProperties
        {
            IsPersistent = isPersistent,
            ExpiresUtc = isPersistent is not false ? dateTimeOffset : null,
        };

        await httpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);
    }

    // GetCurrentUserId
    public int GetCurrentUserId()
    {
        var httpContext = _httpContextAccessor.HttpContext 
            ?? throw new ServerErrorException("HttpContext not found");

        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value 
            ?? throw new AppException(CommonErrorCode.Unauthorized, "Claim nameid not found");

        return int.Parse(userId);
    }
}
