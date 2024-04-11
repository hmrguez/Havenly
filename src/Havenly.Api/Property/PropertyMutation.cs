using Domain.Aggregates;
using Domain.ValueObjects;
using Havenly.Application.Properties;
using Havenly.Contracts.Properties;
using MapsterMapper;

// ReSharper disable once CheckNamespace
namespace Havenly.Api.Properties;

[ExtendObjectType("Mutation")]
public class PropertyMutation(IMapper mapper, IPropertyService propertyService)
{
    public async Task<Guid> AddProperty(PropertyDto propertyDto)
    {
        var property = mapper.Map<Property>(propertyDto);
        var created = await propertyService.ListProperty(property);
        return created.Value;
    }

    public async Task<Guid> UpdateProperty(Property propertyDto)
    {
        var property = mapper.Map<Property>(propertyDto);
        var updated = await propertyService.UpdateProperty(property);
        return updated.Value;
    }
    
    public async Task<Guid> DelistProperty(Guid guid)
    {
        var id = new PropertyId(guid);
        var delisted = await propertyService.DelistProperty(id);
        return delisted.Value;
    }
}