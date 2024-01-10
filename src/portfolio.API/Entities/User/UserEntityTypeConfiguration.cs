using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace portfolio.API.Entities.User;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    

    public void Configure(EntityTypeBuilder<User> builder)
    {
        throw new NotImplementedException();
    }
}