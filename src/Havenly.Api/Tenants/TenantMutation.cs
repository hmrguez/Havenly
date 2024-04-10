using Domain.Aggregates;
using Havenly.Application.Tenants;
using Havenly.Contracts.Tenants;
using MapsterMapper;

namespace Havenly.Api.Tenants;

[ExtendObjectType("Mutation")]
public class TenantMutation(IMapper mapper, ITenantService tenantService)
{
    public async Task<Guid> AddTenant(TenantDto tenantDto)
    {
        var tenant = mapper.Map<Tenant>(tenantDto);
        var created = await tenantService.CreateTenant(tenant);
        return created.Value;
    }

    public async Task<Guid> UpdateTenant(Tenant tenantDto)
    {
        var tenant = mapper.Map<Tenant>(tenantDto);
        var updated = await tenantService.UpdateTenant(tenant);
        return updated.Value;
    }
}