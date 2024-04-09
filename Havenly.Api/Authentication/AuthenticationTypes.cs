using AppAny.HotChocolate.FluentValidation;
using Domain.Errors;
using Havenly.Application.Authentication.Validation;
using HotChocolate.Execution.Configuration;

namespace Havenly.Api.Authentication;

public static class AuthenticationTypes
{
    public static IRequestExecutorBuilder AddAuthentication(this IRequestExecutorBuilder builder)
    {
        return builder
            .AddMutationType<AuthenticationMutation>()
            .AddErrorFilter(error => error.Exception switch
            {
                AuthenticationErrors.DuplicateUserException => error.WithMessage("Duplicate User"),
                AuthenticationErrors.InvalidCredentialsException => error.WithMessage("Invalid credentials"),
                _ => error
            });
    }
}