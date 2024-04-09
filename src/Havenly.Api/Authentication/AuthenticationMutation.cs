using AppAny.HotChocolate.FluentValidation;
using Havenly.Application.Authentication;
using Havenly.Application.Authentication.Services;

namespace Havenly.Api.Authentication;

public class AuthenticationMutation(IAuthenticationService authenticationService)
{
    public Task<AuthenticationResponse> Login([UseFluentValidation] LoginRequest input)
    {
        return authenticationService.Login(input);
    }

    public Task<AuthenticationResponse> Register([UseFluentValidation] RegisterRequest input)
    {
        return authenticationService.Register(input);
    }
}