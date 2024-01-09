
using FastEndpoints;
using MediatR;

namespace portfolio.API.Features.PersonalInformation.CreatePerson;

public class MyEndpoint : Endpoint<MyRequest, MyResponse>
{
    private ISender _sender;

    public MyEndpoint(ISender sender)
    {
        _sender = sender;
    }
    public override void Configure()
    {
        Post("/api/user/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync(MyRequest req, CancellationToken ct)
    {

        var command = new CreateCommand
        {
            first_name = req.First_name,
            last_name = req.Last_name,
            date_of_birth = req.Date_of_birth,
            gender = req.Gender,
            ethnicity = req.Ethnicity
        };

          var personId = await _sender.Send(command);

        if (personId is not > 0)
            await SendErrorsAsync();

        await SendAsync(new(personId, "User Successfully Created"));
    }
}

public record MyResponse(int PersonId, string Message)
{
}

public record class MyRequest(string First_name, string Last_name, string Date_of_birth, string Gender, string Ethnicity)
{
}