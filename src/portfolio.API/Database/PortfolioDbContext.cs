namespace portfolio.API.Database;

using Microsoft.EntityFrameworkCore;
using portfolio.API.Entities.PersonalInfo;

public class PortfolioDbContext : DbContext
{
    public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options) { }
        public DbSet<Person> PersonalInfos { get; set; }
}

