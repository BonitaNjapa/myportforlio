using portfolio.API.Helpers.Extensions;

var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;

Configuration.AddEnvironmentBasedJsonFile(builder.Environment);

builder.Services.AddCustomDbContext(configuration:Configuration);


var app = builder.Build();

app.CheckDatabaseConnection();


app.MapGet("/", () => "Hello World!");

app.Run();
