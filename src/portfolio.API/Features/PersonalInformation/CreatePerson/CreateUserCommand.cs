using MediatR;

namespace portfolio.API.Features.PersonalInformation;


public sealed record CreateUserCommand(
     string Username,
     string FirstName,
     string LastName,
     string MiddleName,
     string Email) : IRequest<string>
{
}
