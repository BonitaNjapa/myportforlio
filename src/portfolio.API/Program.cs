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

    var Configuration = builder.Configuration;

    Configuration.AddEnvironmentBasedJsonFile(builder.Environment,Log.Logger);

    builder.Services.ConfigureServices(Configuration);

    var app = builder.Build();

    app.ConfigureAppExtensions();

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
