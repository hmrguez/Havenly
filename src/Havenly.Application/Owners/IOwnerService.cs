using Domain.Aggregates;
using Domain.ValueObjects;

namespace Havenly.Application.Owners;

public interface IOwnerService
{
    Task<Owner?> GetOwner(OwnerId ownerId);
    Task<OwnerId> CreateOwner(Owner owner);
    Task<OwnerId> UpdateOwner(Owner owner);
}