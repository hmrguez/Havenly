// using Domain.ValueObjects;

using Havenly.Contracts.Amenity;
using Domain.Entities;
using MapsterMapper;

namespace Havenly.Api.Amenity;

[ExtendObjectType("Query")]
public class AmenityQuery(IMapper mapper)
{
    public List<AmenityDto> GetAllAmenities()
    {
        var temp = new List<Domain.Entities.Amenity>
        {
            Domain.Entities.Amenity.Create("Pool"),
            Domain.Entities.Amenity.Create("Gym"),
            Domain.Entities.Amenity.Create("Parking")
        };

        return mapper.Map<List<AmenityDto>>(temp);
    }
}