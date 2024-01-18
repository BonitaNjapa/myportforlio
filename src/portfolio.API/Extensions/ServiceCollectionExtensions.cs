using portfolio.API.Database;
using Microsoft.EntityFrameworkCore;
using portfolio.API.Entities.User;
using Microsoft.AspNetCore.Identity;
using Serilog;
using FastEndpoints;
using FastEndpoints.Security;
using System.Reflection;
using portfolio.API.Shared;

namespace portfolio.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
    {                            
        services.AddDbContext<PortfolioDbContext>(options =>
            options.UseNpgsql(configuration
                            .GetConnectionString("DefaultConnection")));
       
        services.AddIdentityAndProvidersToDb();
        
        services.ConfigureIdentityOptions();
    }

    public static void AddIdentityAndProvidersToDb(this IServiceCollection services) 
        => services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<PortfolioDbContext>()
            .AddDefaultTokenProviders();

    public static void ConfigureIdentityOptions(this IServiceCollection services)
        => services.Configure<IdentityOptions>(options => {});
    
    public static void AddServicesInheritingFrom<TBase>(this IServiceCollection services,Assembly assembly,Serilog.ILogger logger)
    {
        var serviceTypes = assembly.GetExportedTypes()
            .Where(type => type.IsClass && typeof(TBase).IsAssignableFrom(type));

        foreach (var serviceType in serviceTypes)
            services.AddScoped(typeof(TBase), serviceType);

        logger.Information($"Added {serviceTypes.Count()} Services Inheriting From {typeof(TBase).Name}");

    }
    public static void ConfigureServices(this IServiceCollection services,IConfiguration configuration,Assembly assembly,Serilog.ILogger logger)
    {
        services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog());
        services.AddSingleton(Log.Logger);
        services.AddServicesInheritingFrom<ISingletonService>(assembly,logger);

        services
            .AddFastEndpoints()
            .AddJWTBearerAuth("this is my custom Secret key for authentication")
            .AddAuthorization();

        services.AddCustomDbContext(configuration);

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
        
    }
}
