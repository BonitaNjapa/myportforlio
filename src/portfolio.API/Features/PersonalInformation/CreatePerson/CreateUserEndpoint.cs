
using System.Net;
using FastEndpoints;
using MediatR;
using portfolio.API.Shared;

namespace portfolio.API.Features.PersonalInformation.CreatePerson;

public class CreateUserEndpoint : Endpoint<CreateUserRequest,  Results<CreateUserResponse>>
{
    private ISender _sender;

    public CreateUserEndpoint(ISender sender)
    {
        _sender = sender;
    }
    public override void Configure()
    {
        Post("/api/user/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateUserRequest req, CancellationToken ct)
    {
        var command = new CreateUserCommand
        (
            first_name : req.FirstName,
            last_name : req.LastName,
            date_of_birth : req.DateOfBirth,
            gender : req.Gender,
            ethnicity : req.Ethnicity
        );

          var personId = await _sender.Send(command);

        if (personId is not > 0)
            await SendAsync(
                    Results<CreateUserResponse>.ErrorResult(new("Internal Server Error")),
                    (int)HttpStatusCode.InternalServerError,
                    ct);
            
        var successResult = Results<CreateUserResponse>
                            .SuccessResult(
                                new(personId,"User Successfully Created"));

        await SendAsync(
                successResult,
                (int)HttpStatusCode.Created,
                ct);
    }
}
