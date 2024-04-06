﻿using Core.EFCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;

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

    // Add dbconext
    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
    }

    // Add services to the ioc container with reflaection
    public static void AddServices(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var types = assembly.GetTypes().Where(x => x.Namespace != null && x.Namespace.Contains("Services")).ToList();

        foreach (var type in types)
        {
            var interfaceType = type.GetInterface($"I{type.Name}");
            if (interfaceType != null)
            {
                services.AddScoped(interfaceType, type);
            }
        }
    }
}
