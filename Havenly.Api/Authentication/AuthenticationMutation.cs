using Havenly.Application.Authentication;

namespace Havenly.Api.Authentication;

public class AuthenticationMutation(IAuthenticationService authenticationService)
{
    public Task<AuthenticationResponse> Login(LoginRequest input)
    {
        return authenticationService.Login(input);
    }

    public Task<AuthenticationResponse> Register(RegisterRequest input)
    {
        return authenticationService.Register(input);
    }
}