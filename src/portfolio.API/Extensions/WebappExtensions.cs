using portfolio.API.Database;
using Microsoft.EntityFrameworkCore;
using Serilog;
using FastEndpoints;
using Microsoft.AspNetCore.SpaServices.AngularCli;

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

        app.UseStaticFiles();
        if (!app.Environment.IsDevelopment())
        {
            app.UseSpaStaticFiles();
        }

        app.UseSpa(spa =>
        {
            spa.Options.SourcePath = "ClientApp";

            if (app.Environment.IsDevelopment())
            {
                spa.UseAngularCliServer(npmScript: "start");
                //spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
            }
        });


    }
}