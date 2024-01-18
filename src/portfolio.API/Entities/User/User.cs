using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace portfolio.API.Entities.User;


[Table(name: "Users")]
public class User : IdentityUser
{
    public User()
    {

    }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? MiddleName { get; set; }

    // public List<UserRole> UserRoles { get; set; }
    // public List<UserClaim> UserClaims { get; set; }
    // public List<UserPermission> UserPermissions { get; set; }
}