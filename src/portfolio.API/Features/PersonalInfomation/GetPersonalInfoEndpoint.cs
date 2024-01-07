using FastEndpoints;


namespace portfolio.API.Features.PersonalInfomation;

public sealed class GetPersonalInfoEndpoint : EndpointWithoutRequest<GetPersonalInfoResponse>
{
  public override void Configure()
  {
    Get("/api/person");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    await SendAsync(new()
    {
      FirstName = "Ntembeko",
      LastName = "Njapa",
      Age = 28
    });
  }
}
