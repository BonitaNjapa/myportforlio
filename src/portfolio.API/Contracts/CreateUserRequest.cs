namespace portfolio.API.Features.PersonalInformation.CreatePerson;

public record class CreateUserRequest(string Username,
     string FirstName,
     string LastName,
     string MiddleName,
     string Email)
{
}