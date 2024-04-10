using Domain.Aggregates;
using Havenly.Contracts.Amenity;
using Havenly.Contracts.Tenants;
using Mapster;

namespace Havenly.Api.Common.Mapping;

public class TenantMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Tenant, TenantDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.UserId, src => src.UserId.Value);

        config.NewConfig<TenantDto, Tenant>()
            .Map(dest => dest.Id.Value, src => src.Id)
            .Map(dest => dest.UserId.Value, src => src.UserId);
    }
}