using Havenly.Application.Authentication;

namespace Havenly.Api.Authentication;

public class AuthenticationMutation
{
    public async Task<AuthenticationResponse> Login(LoginRequest input)
    {
        await Task.CompletedTask;
        return new AuthenticationResponse(Guid.NewGuid(), "login-token");
    }

    public async Task<AuthenticationResponse> Register(RegisterRequest input)
    {
        await Task.CompletedTask;
        return new AuthenticationResponse(Guid.NewGuid(), "register-token");
    }
}