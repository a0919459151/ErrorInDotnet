using Microsoft.AspNetCore.Authentication.Cookies;

namespace CMS.DI;

public static class DependencyInjection
{
    // Add cookie authentication
    public static void AddCookieAuthentication(this IServiceCollection services)
    {
        services
            .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.LoginPath = "/Auth/Login";
                options.AccessDeniedPath = "/Home/AccessDeny";
            });
    }
}
