using System;
using Havenly.Contracts.Properties;
using Havenly.Contracts.Tenants;

namespace Havenly.Contracts.Leases;

public class LeaseDto
{
    public Guid Id { get; set; }
    public int Rent { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Deposit { get; set; }

    public Guid PropertyId { get; set; }
    public PropertyDto? Property { get; set; }

    public Guid TenantId { get; set; }
    public TenantDto? Tenant { get; set; }
}