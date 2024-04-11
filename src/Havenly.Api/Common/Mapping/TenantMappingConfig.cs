using Domain.Aggregates;
using Domain.Entities;
using Havenly.Contracts.Tenants;
using Havenly.Contracts.Users;
using Mapster;

namespace Havenly.Api.Common.Mapping;

public class TenantMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Tenant, TenantDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.UserId, src => src.UserId.Value)
            .Map(dest => dest.User, src => src.User.Adapt<UserDto>());

        config.NewConfig<TenantDto, Tenant>()
            .Map(dest => dest.Id.Value, src => src.Id)
            .Map(dest => dest.UserId.Value, src => src.UserId)
            .Map(dest => dest.User, src => src.User.Adapt<User>());
    }
}