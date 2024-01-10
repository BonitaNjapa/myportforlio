using MediatR;

namespace portfolio.API.Features.PersonalInformation;


public sealed record CreateUserCommand(string first_name,
                                   string last_name,
                                   string date_of_birth,
                                   string gender,
                                   string ethnicity) : IRequest<int>
{
}
