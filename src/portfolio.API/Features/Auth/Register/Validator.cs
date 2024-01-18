using FastEndpoints;
using FluentValidation;
using portfolio.API.Contracts;

namespace portfolio.API.Features.Auth.Register;
public class Validator : Validator<RegisterUserRequest>
{
    public Validator()
    {
        RuleFor(x => x.FirstName)
        .MinimumLength(3)
        .WithMessage("Minimum Length Violation");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email field cannot be null");
    }
}