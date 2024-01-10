using System.ComponentModel.DataAnnotations.Schema;
using portfolio.API.Entities.BaseEntity;

namespace portfolio.API.Entities.User;


[Table(name:"Users")]
public class User : BaseEntityClass
{
    public User()
    {
        
    }
    public required string Username { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? MiddleName { get; set; }
    public required string Email { get; set; }

    // public List<UserRole> UserRoles { get; set; }
    // public List<UserClaim> UserClaims { get; set; }
    // public List<UserPermission> UserPermissions { get; set; }
}