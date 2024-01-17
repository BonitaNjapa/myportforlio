using portfolio.API.Database;
using Microsoft.EntityFrameworkCore;
using portfolio.API.Entities.User;
using Microsoft.AspNetCore.Identity;
using Serilog;
using FastEndpoints;
using FastEndpoints.Security;
using System.Reflection;
using Carter;

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
    
    public static void AddServicesInheritingFrom<TBaseType>(this IServiceCollection services, Assembly assembly)
    {
        var serviceTypes = assembly.GetExportedTypes()
            .Where(type => type.IsClass && typeof(TBaseType).IsAssignableFrom(type));

        foreach (var serviceType in serviceTypes)
        {
            services.AddSingleton(typeof(TBaseType), serviceType);
        }
    }
    public static void ConfigureServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog());
        services.AddSingleton(Log.Logger);

        services
            .AddFastEndpoints()
            .AddJWTBearerAuth("this is my custom Secret key for authentication")
            .AddAuthorization();

        services.AddCustomDbContext(configuration);

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
        
        services.AddCarter();//ToDO: remove the package as it wont be used anymore!


    }
}
