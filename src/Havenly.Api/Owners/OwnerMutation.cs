using Domain.Aggregates;
using Havenly.Application.Owners;
using Havenly.Contracts.Owners;
using MapsterMapper;

namespace Havenly.Api.Owners;

[ExtendObjectType("Mutation")]
public class OwnerMutation(IMapper mapper, IOwnerService ownerService)
{
    public async Task<Guid> AddOwner(OwnerDto ownerDto)
    {
        var owner = mapper.Map<Owner>(ownerDto);
        var created = await ownerService.CreateOwner(owner);
        return created.Value;
    }

    public async Task<Guid> UpdateOwner(Owner ownerDto)
    {
        var owner = mapper.Map<Owner>(ownerDto);
        var updated = await ownerService.UpdateOwner(owner);
        return updated.Value;
    }
}