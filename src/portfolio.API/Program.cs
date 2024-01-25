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

    Configuration.AddEnvironmentBasedJsonFile(builder.Environment, Log.Logger);

    builder.Services.ConfigureServices(Configuration, typeof(Program).Assembly, Log.Logger);



    var app = builder.Build();


    app.ConfigureAppExtensions();

    app.MapGet("/api/stats", () =>
           {
               return new List<DataItem>
               {
                new DataItem { Name = "Budget", IconBg = "icon icon-shape bg-danger text-white text-lg rounded-circle", Icon = "bi bi-credit-card", Value = "$750.90" },
                new DataItem { Name = "New projects", IconBg = "icon icon-shape bg-primary text-white text-lg rounded-circle", Icon = "bi bi-people", Value = "215" },
                new DataItem { Name = "Total hours", IconBg = "icon icon-shape bg-info text-white text-lg rounded-circle", Icon = "bi bi-clock-history", Value = "1.400" },
                new DataItem { Name = "Work load", IconBg = "icon icon-shape bg-warning text-white text-lg rounded-circle", Icon = "bi bi-minecart-loaded", Value = "95%" }
               };
           });

    app.MapGet("/stats", () =>
           {
               return new List<DataItem>
               {
                new DataItem { Name = "Budget", IconBg = "icon icon-shape bg-danger text-white text-lg rounded-circle", Icon = "bi bi-credit-card", Value = "$750.90" },
                new DataItem { Name = "New projects", IconBg = "icon icon-shape bg-primary text-white text-lg rounded-circle", Icon = "bi bi-people", Value = "215" },
                new DataItem { Name = "Total hours", IconBg = "icon icon-shape bg-info text-white text-lg rounded-circle", Icon = "bi bi-clock-history", Value = "1.400" },
                new DataItem { Name = "Work load", IconBg = "icon icon-shape bg-warning text-white text-lg rounded-circle", Icon = "bi bi-minecart-loaded", Value = "95%" }
               };
           });

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
public class DataItem
{
  
    public required string Name { get; init; }
    public required string IconBg { get; init; }
    public required string Icon { get; init; }
    public required string Value { get; init; }
}