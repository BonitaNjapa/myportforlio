using Carter;
using FastEndpoints;
using FastEndpoints.Security;

using Microsoft.EntityFrameworkCore;
using portfolio.API.Database;
using portfolio.API.Extensions;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();



try
{
    Log.Information("Starting web application");

    builder.Host.UseSerilog();
    

    builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog());

    builder.Services.AddSingleton(Log.Logger);

    var Configuration = builder.Configuration;

    Configuration.AddEnvironmentBasedJsonFile(builder.Environment,Log.Logger);

    builder.Services
            .AddFastEndpoints()
            .AddJWTBearerAuth("this is my custom Secret key for authentication")
            .AddAuthorization();;

    builder.Services.AddCustomDbContext(configuration: Configuration,Log.Logger);

    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

    builder.Services.AddCarter();

    var app = builder.Build();
    
    app.UseSerilogRequestLogging();
    
    app.CheckDatabaseConnection(Log.Logger);

    app.UseAuthentication()
        .UseAuthorization() 
        .UseFastEndpoints();

    app.MapCarter();

    app.MapGet("/", async (PortfolioDbContext dbContext) => Results.Ok(await dbContext.Users.ToListAsync()));

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
