using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace portfolio.API.Entities.User;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{


    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(new User()
        {
            Username = "testUser123",
            FirstName = "John",
            LastName = "Doe",
            MiddleName = "M",
            Email = "john.doe@example.com",
            Id = Guid.Parse("728277a2-bdac-4d99-b854-429e1fd37c02"),
            CreatedAt = DateTime.Parse("2024-01-01T00:00:00").ToUniversalTime(),
            UpdatedAt = DateTime.Parse("2024-01-01T00:00:00").ToUniversalTime(),
            IsDeleted = false
        });
    }
}