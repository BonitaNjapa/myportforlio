using portfolio.API.Database;
using Microsoft.EntityFrameworkCore;
using Serilog;
using FastEndpoints;
using Carter;

namespace portfolio.API.Extensions;

public static class WebappExtensions
{
    public static void CheckDatabaseConnection(this WebApplication app, Serilog.ILogger logger)
    {
        try
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<PortfolioDbContext>();
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
    public static void AddEnvironmentBasedJsonFile(this IConfigurationBuilder configurationBuilder, IWebHostEnvironment environment, Serilog.ILogger logger)
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
    public static void ConfigureAppExtensions(this WebApplication app)
    {
        app.UseSerilogRequestLogging();
        app.CheckDatabaseConnection(Log.Logger);
         
        app.UseAuthentication()
            .UseAuthorization() 
            .UseFastEndpoints();
        
        app.MapCarter();
        app.MapGet("/", async (PortfolioDbContext dbContext) => Results.Ok(await dbContext.Users.ToListAsync()));

    }
}
