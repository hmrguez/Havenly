// using Domain.ValueObjects;

using Domain.ValueObjects;
using Havenly.Application.Amenities;
using Havenly.Application.Tenants;
using Havenly.Contracts.Amenity;
using Havenly.Contracts.Tenants;
using MapsterMapper;

namespace Havenly.Api.Tenants;

[ExtendObjectType("Query")]
public class TenantQuery(IMapper mapper, ITenantService tenantService)
{
    public async Task<TenantDto> GetTenant(Guid guid)
    {
        var tenant = await tenantService.GetTenant(new TenantId(guid));
        if (tenant == null)
        {
            throw new Exception("Tenant not found");
        }

        return mapper.Map<TenantDto>(tenant);
    }
}