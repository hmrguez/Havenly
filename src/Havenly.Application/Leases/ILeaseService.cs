using System;
using System.Threading.Tasks;
using Domain.Aggregates;
using Havenly.Contracts.Leases;

namespace Havenly.Application.Leases
{
    public interface ILeaseService
    {
        Task<Lease?> GetLease(Guid leaseId);
        Task<Guid> CreateLease(Lease lease);
        Task<Guid> RenewLease(Guid leaseId);
        Task<Guid> TerminateLease(Guid leaseId);
        Task<Guid> UpdateLease(Lease lease);
        Task<Guid> CreateFromScratch(CreateLeaseTenantDto lease);
    }
}