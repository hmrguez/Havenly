// src/Havenly.Application/Leases/LeaseService.cs

using System;
using System.Threading.Tasks;
using Domain.Aggregates;
using Domain.Entities;
using Domain.ValueObjects;
using Havenly.Application.Common.Interfaces.Persistence;
using Havenly.Contracts.Leases;

namespace Havenly.Application.Leases
{
    public class LeaseService(
        IRepository<Lease, Guid> leaseRepository,
        IRepository<User, UserId> userRepository,
        IRepository<Tenant, TenantId> tenantRepository)
        : ILeaseService
    {
        public Task<Lease?> GetLease(Guid leaseId)
        {
            return leaseRepository.GetById(leaseId, "Property", "Tenant");
        }

        public async Task<Guid> CreateLease(Lease lease)
        {
            lease.Id = Guid.NewGuid();
            await leaseRepository.Add(lease);
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
            await leaseRepository.Update(lease);
            return lease.Id;
        }

        public async Task<Guid> CreateFromScratch(CreateLeaseTenantDto dto)
        {
            var newUser = User.Create(dto.Name, dto.Password, dto.Email, false, dto.ContactInfo);
            var newTenant = Tenant.Create(newUser.Id, dto.Age, dto.AverageSalary, dto.Gender);
            var newLease = Lease.Create(new PropertyId(dto.PropertyId), newTenant.Id, dto.Rent, dto.StartDate,
                dto.EndDate, dto.Deposit);

            await userRepository.Add(newUser);
            await tenantRepository.Add(newTenant);
            await leaseRepository.Add(newLease);

            return newLease.Id;
        }
    }
}