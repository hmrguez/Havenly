using Domain.Entities;
using Domain.Errors;
using Havenly.Application.Common.Interfaces.Authentication;
using Havenly.Application.Common.Interfaces.Persistence;

namespace Havenly.Application.Authentication.Services;

public class AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    : IAuthenticationService
{
    public async Task<AuthenticationResponse> Login(LoginRequest input)
    {
        if (await userRepository.GetByEmail(input.Email) is not { } user)
            throw new AuthenticationErrors.InvalidCredentialsException("Invalid Email");

        if (user.Password != input.Password)
            throw new AuthenticationErrors.InvalidCredentialsException("Invalid Password");

        return new AuthenticationResponse(Guid.NewGuid(), jwtTokenGenerator.GenerateToken(user.Id, input.Email));
    }

    public async Task<AuthenticationResponse> Register(RegisterRequest input)
    {
        if (await userRepository.GetByEmail(input.Email) != null)
            throw new AuthenticationErrors.DuplicateUserException("Duplicate User");

        var user = new User
        {
            Email = input.Email,
            Password = input.Password,
            Name = input.Username
        };

        await userRepository.Add(user);
        return new AuthenticationResponse(Guid.NewGuid(), jwtTokenGenerator.GenerateToken(user.Id, user.Email));
    }
}