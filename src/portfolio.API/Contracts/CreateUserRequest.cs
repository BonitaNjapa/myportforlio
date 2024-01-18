namespace portfolio.API.Contracts;

public record class RegisterUserRequest(string Username,
     string FirstName,
     string LastName,
     string MiddleName,
     string Email)
{
}
public record class LoginRequest(string Username,
     string Password)
{
}