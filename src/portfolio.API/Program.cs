using Carter;
using portfolio.API.Helpers.Extensions;

var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;

Configuration.AddEnvironmentBasedJsonFile(builder.Environment);

builder.Services.AddCustomDbContext(configuration:Configuration);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();

app.CheckDatabaseConnection();

app.MapCarter();

app.MapGet("/", () => "Hello World!");

app.Run();
