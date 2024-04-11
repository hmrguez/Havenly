using Domain.Entities;
using Domain.ValueObjects;
using Havenly.Contracts.Amenity;
using Mapster;

namespace Havenly.Api.Common.Mapping;

public class AmenityMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Amenity, AmenityDto>().MapWith(src => new AmenityDto
        {
            Id = src.Id.Value,
            Name = src.Name,
        });

        config.NewConfig<AmenityDto, Amenity>().MapWith(src => new Amenity
        {
            Id = new AmenityId(src.Id),
            Name = src.Name,
        });
    }
}