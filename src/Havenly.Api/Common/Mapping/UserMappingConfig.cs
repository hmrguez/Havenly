using Domain.Aggregates;
using Domain.Entities;
using Havenly.Contracts.Tenants;
using Havenly.Contracts.Users;
using Mapster;

namespace Havenly.Api.Common.Mapping;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<User, UserDto>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<UserDto, User>()
            .Map(dest => dest.Id.Value, src => src.Id);
    }
}