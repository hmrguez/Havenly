// src/Havenly.Application/Leases/LeaseService.cs

using System;
using System.Threading.Tasks;
using Domain.Aggregates;
using Havenly.Application.Common.Interfaces.Persistence;

namespace Havenly.Application.Leases
{
    public class LeaseService : ILeaseService
    {
        private readonly IRepository<Lease, Guid> _leaseRepository;

        public LeaseService(IRepository<Lease, Guid> leaseRepository)
        {
            _leaseRepository = leaseRepository;
        }

        public Task<Lease?> GetLease(Guid leaseId)
        {
            return _leaseRepository.GetById(leaseId, "Property", "Tenant");
        }

        public async Task<Guid> CreateLease(Lease lease)
        {
            lease.Id = Guid.NewGuid();
            await _leaseRepository.Add(lease);
            return lease.Id;
        }

        public async Task<Guid> RenewLease(Guid leaseId)
        {
            // Add your logic for renewing a lease here
            throw new NotImplementedException();
        }

        public async Task<Guid> TerminateLease(Guid leaseId)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> UpdateLease(Lease lease)
        {
            await _leaseRepository.Update(lease);
            return lease.Id;
        }
    }
}