namespace Havenly.Application.Authentication;

public interface IAuthenticationService
{
    Task<AuthenticationResponse> Login(LoginRequest input);
    Task<AuthenticationResponse> Register(RegisterRequest input);
}