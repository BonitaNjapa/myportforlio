using MediatR;

namespace portfolio.API.Features.PersonalInformation;


public sealed record CreateCommand : IRequest<int>
{
    public string first_name { get; set; } = string.Empty;
    public string last_name { get; set; } = string.Empty;
    public string date_of_birth { get; set; } = string.Empty;
    public string gender { get; set; } = string.Empty;
    public string ethnicity { get; set; } = string.Empty;
}
