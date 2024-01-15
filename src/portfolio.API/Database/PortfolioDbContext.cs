namespace portfolio.API.Database;

using Microsoft.EntityFrameworkCore;
using portfolio.API.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class PortfolioDbContext : IdentityDbContext<User>
{
    public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options) { }
        public override DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
        base.OnModelCreating(modelBuilder);
    }

}

