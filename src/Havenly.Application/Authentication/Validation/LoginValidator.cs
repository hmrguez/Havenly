using FluentValidation;

namespace Havenly.Application.Authentication.Validation;

public class LoginValidator : AbstractValidator<LoginRequest>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid Email");
        RuleFor(x => x.Password).MinimumLength(6).WithMessage("Password must be at least 6 characters long");
    }
}