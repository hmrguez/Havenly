// using Domain.ValueObjects;

using Domain.ValueObjects;
using Havenly.Application.Amenities;
using Havenly.Application.Owners;
using Havenly.Contracts.Amenity;
using Havenly.Contracts.Owners;
using MapsterMapper;

namespace Havenly.Api.Owners;

[ExtendObjectType("Query")]
public class OwnerQuery(IMapper mapper, IOwnerService tenantService)
{
    public async Task<OwnerDto> GetOwner(Guid guid)
    {
        var tenant = await tenantService.GetOwner(new OwnerId(guid));
        if (tenant == null)
        {
            throw new Exception("Owner not found");
        }

        return mapper.Map<OwnerDto>(tenant);
    }
}