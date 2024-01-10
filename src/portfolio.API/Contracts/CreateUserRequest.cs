namespace portfolio.API.Features.PersonalInformation.CreatePerson;

public record class CreateUserRequest(string FirstName, string LastName, string DateOfBirth, string Gender, string Ethnicity)
{
}