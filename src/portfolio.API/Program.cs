using Carter;
using FastEndpoints;
using portfolio.API.Helpers.Extensions;

var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;

Configuration.AddEnvironmentBasedJsonFile(builder.Environment);

builder.Services.AddFastEndpoints();

builder.Services.AddCustomDbContext(configuration:Configuration);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
    
builder.Services.AddCarter();

var app = builder.Build();

app.CheckDatabaseConnection();

app.UseFastEndpoints();

app.MapCarter();

app.MapGet("/", () => "Hello World!");

app.Run();
