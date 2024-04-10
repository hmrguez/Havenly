using Havenly.Contracts.Amenity;
using Mapster;

namespace Havenly.Api.Common.Mapping;

public class AmenityMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Domain.Entities.Amenity, AmenityDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Name, src => src.Name);
    }
}