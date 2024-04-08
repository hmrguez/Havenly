using Havenly.Application.Common.Interfaces.Authentication;

namespace Havenly.Application.Authentication;

public class AuthenticationService(IJwtTokenGenerator jwtTokenGenerator) : IAuthenticationService
{
    public async Task<AuthenticationResponse> Login(LoginRequest input)
    {
        Guid userId = new Guid();

        await Task.CompletedTask;
        return new AuthenticationResponse(Guid.NewGuid(), jwtTokenGenerator.GenerateToken(userId, input.Email));
    }

    public async Task<AuthenticationResponse> Register(RegisterRequest input)
    {
        Guid userId = new Guid();

        await Task.CompletedTask;
        return new AuthenticationResponse(Guid.NewGuid(), jwtTokenGenerator.GenerateToken(userId, input.Email));
    }
}