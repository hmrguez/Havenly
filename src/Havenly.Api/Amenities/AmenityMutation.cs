using Havenly.Application.Amenities;
using MapsterMapper;

namespace Havenly.Api.Amenities;

[ExtendObjectType("Mutation")]
public class AmenityMutation(IAmenityService amenityService)
{
    public Task<Guid> AddAmenity(string name)
    {
        return amenityService.Add(name);
    }
}

