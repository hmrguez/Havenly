using Domain.Aggregates;
using Domain.Entities;
using Domain.Errors;
using Domain.ValueObjects;
using Havenly.Application.Common.Interfaces.Authentication;
using Havenly.Application.Common.Interfaces.Persistence;

namespace Havenly.Application.Authentication.Services;

public class AuthenticationService(
    IJwtTokenGenerator jwtTokenGenerator,
    IRepository<User, UserId> userRepository,
    IRepository<Owner, OwnerId> ownerRepository)
    : IAuthenticationService
{
    public async Task<AuthenticationResponse> Login(LoginRequest input)
    {
        var user = await userRepository.GetByProperty(u => u.Email, input.Email);

        if (user is null)
            throw new AuthenticationErrors.InvalidCredentialsException("Invalid Email");

        if (user.Password != input.Password)
            throw new AuthenticationErrors.InvalidCredentialsException("Invalid Password");

        return new AuthenticationResponse(Guid.NewGuid(), jwtTokenGenerator.GenerateToken(user.Id.Value, input.Email, user.IsOwner));
    }

    public async Task<AuthenticationResponse> Register(RegisterRequest input)
    {
        var existingUser = await userRepository.GetByProperty(u => u.Email, input.Email);

        if (existingUser != null)
            throw new AuthenticationErrors.DuplicateUserException("Duplicate User");

        var user = User.Create(
            input.Username,
            input.Password,
            input.Email,
            false,
            input.ContactInfo);

        var owner = Owner.Create(user.Id);

        await userRepository.Add(user);
        await ownerRepository.Add(owner);

        return new AuthenticationResponse(Guid.NewGuid(), jwtTokenGenerator.GenerateToken(user.Id.Value, user.Email, true));
    }
}