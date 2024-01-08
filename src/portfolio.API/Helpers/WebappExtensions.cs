using portfolio.API.Database;

namespace portfolio.API.Helpers;

public static class WebappExtensions
{
    public static void CheckDatabaseConnection(this WebApplication app)
    {
        try
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<PortfolioDbContext>();
            context.Database.EnsureCreated();
            Console.WriteLine($"{nameof(context)} is online!!!:)");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine("Database is offline or connection failed. Exiting application.");
            Environment.Exit(1);
        }
    }
}