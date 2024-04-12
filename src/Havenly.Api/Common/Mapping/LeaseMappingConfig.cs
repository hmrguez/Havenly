using Domain.Aggregates;
using Domain.ValueObjects;
using Havenly.Contracts.Leases;
using Havenly.Contracts.Properties;
using Havenly.Contracts.Tenants;
using Mapster;

namespace Havenly.Api.Common.Mapping;

public class LeaseMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Lease, LeaseDto>().MapWith(src => new LeaseDto()
        {
            Deposit = src.Deposit,
            EndDate = src.EndDate,
            Id = src.Id,
            Rent = src.Rent,
            StartDate = src.StartDate,
            PropertyId = src.PropertyId.Value,
            TenantId = src.TenantId.Value,
            Tenant = src.Tenant.Adapt<TenantDto>(),
            Property = src.Property.Adapt<PropertyDto>(),
        });

        config.NewConfig<LeaseDto, Lease>().MapWith(src => new Lease()
        {
            Deposit = src.Deposit,
            EndDate = src.EndDate,
            Id = src.Id,
            Rent = src.Rent,
            StartDate = src.StartDate,
            PropertyId = new PropertyId(src.PropertyId),
            TenantId = new TenantId(src.TenantId),
            Tenant = src.Tenant.Adapt<Tenant>(),
            Property = src.Property.Adapt<Property>(),
        });
    }
}