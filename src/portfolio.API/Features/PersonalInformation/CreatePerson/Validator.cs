using FastEndpoints;
using FluentValidation;

namespace portfolio.API.Features.PersonalInformation.CreatePerson;
public class Validator : Validator<CreateUserRequest>
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