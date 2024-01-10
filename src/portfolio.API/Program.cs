using Carter;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using portfolio.API.Database;
using portfolio.API.Extensions;

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

app.MapGet("/", async (PortfolioDbContext dbContext) =>  Results.Ok(await dbContext.Users.ToListAsync()));

app.Run();
