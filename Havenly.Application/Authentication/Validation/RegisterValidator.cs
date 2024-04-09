using FluentValidation;

namespace Havenly.Application.Authentication.Validation;

public class RegisterValidator : AbstractValidator<RegisterRequest>
{
    public RegisterValidator()
    {
        RuleFor(x => x.Username).MinimumLength(3).WithMessage("Username must be at least 3 characters long");
        RuleFor(x => x.Password).MinimumLength(6).WithMessage("Password must be at least 6 characters long");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid Email");
    }
}