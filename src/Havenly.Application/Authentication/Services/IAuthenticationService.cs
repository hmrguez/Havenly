namespace Havenly.Application.Authentication.Services;

public interface IAuthenticationService
{
    Task<AuthenticationResponse> Login(LoginRequest input);
    Task<AuthenticationResponse> Register(RegisterRequest input);
}