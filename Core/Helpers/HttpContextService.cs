using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Core.Helpers;

public class HttpContextService
{
    private readonly HttpContext _httpContext;

    public HttpContextService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContext =  httpContextAccessor.HttpContext ?? throw new Exception("HttpContext not found");
    }

    // Login
    public async Task Login(Admin admin, bool isPersistent)
    {
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

        await _httpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);
    }

    // GetCurrentUserId
    public int GetCurrentUserId()
    {
        var userId = _httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userId is null)
        {
            throw new Exception("User not found");
        }

        return int.Parse(userId);
    }
}
