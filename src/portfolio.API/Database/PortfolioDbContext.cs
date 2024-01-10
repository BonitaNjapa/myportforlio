namespace portfolio.API.Database;

using Microsoft.EntityFrameworkCore;
using portfolio.API.Entities.User;

public class PortfolioDbContext : DbContext
{
    public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
}

