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
    
    public static void AddServicesInheritingFrom<ISingletonService>(this IServiceCollection services,Assembly assembly)
    {
        var serviceTypes = assembly.GetExportedTypes()
            .Where(type => type.IsClass && typeof(ISingletonService).IsAssignableFrom(type));

        foreach (var serviceType in serviceTypes)
            services.AddSingleton(typeof(ISingletonService), serviceType);        
    }
    public static void ConfigureServices(this IServiceCollection services,IConfiguration configuration,Assembly assembly)
    {
        services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog());
        services.AddSingleton(Log.Logger);
        services.AddServicesInheritingFrom<IServiceCollection>(assembly);

        services
            .AddFastEndpoints()
            .AddJWTBearerAuth("this is my custom Secret key for authentication")
            .AddAuthorization();

        services.AddCustomDbContext(configuration);

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
        
        services.AddCarter();//ToDO: remove the package as it wont be used anymore!


    }
}
