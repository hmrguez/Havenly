using Domain.Aggregates;
using Domain.ValueObjects;
using Havenly.Application.Common.Interfaces.Persistence;

namespace Havenly.Application.Tenants;

public class TenantService(IRepository<Tenant, TenantId> repository) : ITenantService
{
    public async Task<TenantId> CreateTenant(Tenant tenant)
    {
        var newTenant = Tenant.Create(tenant.UserId, tenant.Age, tenant.AverageSalary, tenant.Deposit);
        await repository.Add(newTenant);
        return newTenant.Id;
    }

    public async Task<TenantId> UpdateTenant(Tenant tenant)
    {
        await repository.Update(tenant);
        return tenant.Id;
    }

    public Task<Tenant?> GetTenant(TenantId tenantId)
    {
        return repository.GetById(tenantId);
    }
}