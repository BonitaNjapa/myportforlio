using portfolio.API.Database;
using Microsoft.EntityFrameworkCore;
using portfolio.API.Shared;
using portfolio.API.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace portfolio.API.Extensions;

public static class WebappExtensions
{
    public static void CheckDatabaseConnection(this WebApplication app, Serilog.ILogger logger)
    {
        try
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<PortfolioDbContext>();
            logger.Information("");
            context.Database.EnsureDeleted();
            logger.Information("Ensure Database Deleted");
            context.Database.EnsureCreated();
            logger.Information("Ensure Database Created");
            context.Database.Migrate();
            logger.Information("Migrating Database to Latest Version");
            logger.Information($"{context.Database.GetDbConnection().Database.ToUpper()} is online!!!:)");
        }
        catch (Exception ex)
        {
            logger.Error($"Error: {ex.Message}");
            logger.Error("Database is offline or connection failed. Exiting application.");
            Environment.Exit(1);
        }
    }
    public static void AddEnvironmentBasedJsonFile(this IConfigurationBuilder configurationBuilder, IWebHostEnvironment environment,Serilog.ILogger logger)
    {
        if (environment.IsDevelopment())
        {
            configurationBuilder.AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: false);
            logger.Information("environment is development");
            logger.Information("using development appsettings");
        }
        else
            configurationBuilder.AddJsonFile("appsettings.json", optional: false);
    }
}

public static class ServiceCollectionExtensions
{
    public static void AddCustomDbContext(this IServiceCollection services, IConfiguration configuration,Serilog.ILogger logger)
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
    
}
