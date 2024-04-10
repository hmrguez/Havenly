// using Domain.ValueObjects;

using Domain.Entities;
using Havenly.Application.Amenities;
using Havenly.Contracts.Amenity;
using MapsterMapper;

namespace Havenly.Api.Amenities;

[ExtendObjectType("Query")]
public class AmenityQuery(IMapper mapper, IAmenityService amenityService)
{
    public async Task<List<AmenityDto>> GetAllAmenities()
    {
        var amenities = await amenityService.GetAll();
        return mapper.Map<List<AmenityDto>>(amenities);
    }
}