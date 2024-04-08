namespace Havenly.Application.Authentication;

public class AuthenticationService : IAuthenticationService
{
    public async Task<AuthenticationResponse> Login(LoginRequest input)
    {
        await Task.CompletedTask;
        return new AuthenticationResponse(new Guid(), "login-token");
    }

    public async Task<AuthenticationResponse> Register(RegisterRequest input)
    {
        await Task.CompletedTask;
        return new AuthenticationResponse(new Guid(), "register-token");
    }
}