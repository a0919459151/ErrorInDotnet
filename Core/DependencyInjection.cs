using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core.DI;

public static class DependencyInjection
{
    // Add dbconext
    public static void AddDbContext(this IServiceCollection services)
    {
        // Get connection string
        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
    }

    // Add helpers
    public static void AddHelpers(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

        services.AddSingleton<AESEncrypter>();
        services.AddScoped<HttpContextService>();
        services.AddSingleton<JwtHelper>();
        services.AddSingleton<PasswordHasher>();
        services.AddSingleton<MailSender>();
        services.AddSingleton<RandomService>();
        services.AddSingleton<ToasterHelper>();

        services.Configure<SMTPOption>(configuration.GetSection(SMTPOption.SMTP));
    }

    // Add services to the ioc container with reflection
    public static void AddServices(this IServiceCollection services)
    {
        // Get all types in the entry assembly, which end with Service
        var assembly = Assembly.GetEntryAssembly() ?? throw new Exception("Entry assembly not found");
        var types = assembly.GetTypes()
            .Where(type => type.IsClass
                && !string.IsNullOrEmpty(type.Namespace) && type.Namespace.Contains("Services")
                && !string.IsNullOrEmpty(type.Name) && type.Name.EndsWith("Service"))
            .ToList();

        foreach (var type in types)
        {
            var interfaceType = type.GetInterface($"I{type.Name}");
            if (interfaceType == null) continue;
            services.AddScoped(interfaceType, type);
        }
    }
}
