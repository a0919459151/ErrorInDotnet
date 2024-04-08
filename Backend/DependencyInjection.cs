using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Backend.DI;

public static class DependencyInjection
{
    // Add jwt authentication
    public static void AddJwtAuthentication(this IServiceCollection services)
    {
        // Get secret key
        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
        var secretKey = configuration["JwtSettings:SecretKey"] ?? throw new Exception("Jwt secret key not found");

        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
    }

    // Add all allow cors
    public static void AddAllAllowCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins("http://localhost:5173")
                    .AllowCredentials();
            });
        });
    }
}
