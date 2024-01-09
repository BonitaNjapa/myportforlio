using portfolio.API.Database;
using Microsoft.EntityFrameworkCore;

namespace portfolio.API.Helpers.Extensions;

public static class WebappExtensions
{
    public static void CheckDatabaseConnection(this WebApplication app)
    {
        try
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<PortfolioDbContext>();
            context.Database.EnsureCreated();
            context.Database.Migrate();
            Console.WriteLine($"{nameof(context)} is online!!!:)");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine("Database is offline or connection failed. Exiting application.");
            Environment.Exit(1);
        }
    }
    public static void AddEnvironmentBasedJsonFile(this IConfigurationBuilder configurationBuilder, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
            configurationBuilder.AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: false);
        else
            configurationBuilder.AddJsonFile("appsettings.json", optional: false);
    }
}

public static class ServiceCollectionExtensions
{
    public static void AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var dbSettings = configuration.GetSection("ConnectionStrings:DefaultConnection").Get<DatabaseSettings>();
        services.AddDbContext<PortfolioDbContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
    }
}