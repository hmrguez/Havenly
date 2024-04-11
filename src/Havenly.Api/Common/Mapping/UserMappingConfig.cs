using Domain.Aggregates;
using Domain.Entities;
using Domain.ValueObjects;
using Havenly.Contracts.Tenants;
using Havenly.Contracts.Users;
using Mapster;

namespace Havenly.Api.Common.Mapping;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<User, UserDto>().MapWith(src => new UserDto
        {
            Id = src.Id.Value,
            Email = src.Email,
            Name = src.Name,
            ContactInfo = src.ContactInfo,
            IsOwner = src.IsOwner
        });

        config.NewConfig<UserDto, User>().MapWith(src => new User
        {
            Id = new UserId(src.Id),
            Email = src.Email,
            Name = src.Name,
            ContactInfo = src.ContactInfo,
            IsOwner = src.IsOwner
        });
    }
}