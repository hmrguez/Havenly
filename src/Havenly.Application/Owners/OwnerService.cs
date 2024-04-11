using Domain.Aggregates;
using Domain.ValueObjects;
using Havenly.Application.Common.Interfaces.Persistence;

namespace Havenly.Application.Owners;

public class OwnerService(IRepository<Owner, OwnerId> repository) : IOwnerService
{
    public Task<Owner?> GetOwner(OwnerId ownerId)
    {
        return repository.GetById(ownerId);
    }
    
    public async Task<OwnerId> CreateOwner(Owner owner)
    {
        owner = Owner.Create(owner.UserId);
        await repository.Add(owner);
        return owner.Id;
    }

    public async Task<OwnerId> UpdateOwner(Owner owner)
    {
        await repository.Update(owner);
        return owner.Id;
    }
}