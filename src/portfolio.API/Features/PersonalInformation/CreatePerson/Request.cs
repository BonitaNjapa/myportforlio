using MediatR;

namespace portfolio.API.Features.PersonalInformation.CreatePerson;

public record CreateRequest : IRequest<int>
{
    public required string first_name { get; set; }
    public required string last_name { get; set; }
    public required string date_of_birth { get; set; }
    public required string gender { get; set; }
    public required string ethnicity { get; set; }
}
