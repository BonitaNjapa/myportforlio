
using System.Net;
using FastEndpoints;
using MediatR;
using portfolio.API.Shared;

namespace portfolio.API.Features.PersonalInformation.CreatePerson;

public class CreateUserEndpoint : Endpoint<CreateUserRequest, Results<CreateUserResponse>>
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
            FirstName: req.FirstName,
            LastName: req.LastName,
            MiddleName: req.MiddleName,
            Email: req.Email,
            Username: req.Username
        );

        var personId = await _sender.Send(command);

        if (string.IsNullOrEmpty(personId.ToString())) //ToDO: properly check if the guid is valid
            await SendAsync(
                    Results<CreateUserResponse>.ErrorResult(new(
                        "Internal Server Error")),
                    (int)HttpStatusCode.InternalServerError,
                    ct);

        var successResult = Results<CreateUserResponse>
                            .SuccessResult(
                                new(personId, "User Successfully Created"));

        await SendAsync(
                successResult,
                (int)HttpStatusCode.Created,
                ct);
    }
}
