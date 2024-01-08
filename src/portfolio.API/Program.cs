using FastEndpoints;
using portfolio.API.Database;
using Microsoft.EntityFrameworkCore;
using portfolio.API.Helpers;

var builder = WebApplication.CreateBuilder(args);


var Configuration = builder.Configuration;

var dbSettings = Configuration.GetSection("ConnectionStrings:DefaultConnection").Get<DatabaseSettings>();

builder.Services.AddDbContext<PortfolioDbContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddFastEndpoints();

var app = builder.Build();

app.CheckDatabaseConnection();
app.UseFastEndpoints();

app.MapGet("/", () => "Hello World!");

app.Run();
