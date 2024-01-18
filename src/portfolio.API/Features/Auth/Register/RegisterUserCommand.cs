using MediatR;

namespace portfolio.API.Features.Auth.Register;


public sealed record RegisterUserCommand(
     string Username,
     string FirstName,
     string LastName,
     string MiddleName,
     string Email) : IRequest<string>
{
}
