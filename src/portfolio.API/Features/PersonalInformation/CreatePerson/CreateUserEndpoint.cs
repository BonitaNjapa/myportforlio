
using System.Net;
using FastEndpoints;
using FastEndpoints.Security;
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
public class UserLoginEndpoint : Endpoint<LoginRequest>
{
    public override void Configure()
    {
        Post("/api/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        if (!string.IsNullOrEmpty(req.Username))
        {

            (string claimType, string claimValue)[] claims = new (string, string)[4];
            claims[0] = ("UserName", req.Username);
            claims[1] = ("Reports", "ReadReport");
            claims[2] = ("Reports", "WriteReport");
            claims[3] = ("Reports", "DeleteReport");
            
            
            var jwtToken = JWTBearer.CreateToken(
                signingKey: "this is my custom Secret key for authentication",
                expireAt: DateTime.UtcNow.AddDays(1),
                permissions: new List<string> { "ManageUsers", "ManageInventory", "ReadReport","WriteReport","DeleteReport"},
                roles: new List<string> { "Manager" },
                claims: claims
            );

            await SendAsync(new
            {
                Username = req.Username,
                Token = jwtToken
            });
        }
        else
        {
            ThrowError("The supplied credentials are invalid!");
        }
    }
}