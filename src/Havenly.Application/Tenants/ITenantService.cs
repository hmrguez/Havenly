using Domain.Aggregates;
using Domain.ValueObjects;

namespace Havenly.Application.Tenants;

public interface ITenantService
{
    Task<TenantId> CreateTenant(Tenant tenant);
    Task<TenantId> UpdateTenant(Tenant tenant);
    Task<Tenant?> GetTenant(TenantId tenantId);
}