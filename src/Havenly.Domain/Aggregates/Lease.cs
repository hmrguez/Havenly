using Domain.Common.Models;
using Domain.ValueObjects;

namespace Domain.Aggregates;

public class Lease : AggregateRoot<Guid>
{
    public int Rent { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Deposit { get; set; }

    public PropertyId PropertyId { get; set; }
    public TenantId TenantId { get; set; }

    public Property Property { get; set; } = null!;
    public Tenant Tenant { get; set; } = null!;


    public Lease()
    {
    }

    private Lease(Guid id, PropertyId propertyId, TenantId tenantId, int rent, DateTime startDate, DateTime endDate,
        int deposit) : base(id)
    {
        Rent = rent;
        StartDate = startDate;
        EndDate = endDate;
        Deposit = deposit;
        PropertyId = propertyId;
        TenantId = tenantId;
    }

    public static Lease Create(PropertyId propertyId, TenantId tenantId, int rent, DateTime startDate,
        DateTime endDate, int deposit)
    {
        return new Lease(Guid.NewGuid(), propertyId, tenantId, rent, startDate, endDate, deposit);
    }
}