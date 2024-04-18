using Domain.ValueObjects;
using Havenly.Application.Properties;
using Havenly.Contracts.Properties;
using MapsterMapper;

// ReSharper disable once CheckNamespace
namespace Havenly.Api.Properties;

[ExtendObjectType("Query")]
public class PropertyQuery(IMapper mapper, IPropertyService propertyService)
{
    public async Task<PropertyDto> GetProperty(Guid guid)
    {
        var property = await propertyService.GetProperty(new PropertyId(guid));
        if (property == null)
        {
            throw new Exception("Property not found");
        }

        return mapper.Map<PropertyDto>(property);
    }
    
    public async Task<IEnumerable<PropertyDto>> GetAllProperties()
    {
        var properties = await propertyService.GetAllProperties();
        return mapper.Map<IEnumerable<PropertyDto>>(properties);
    }
    
    public async Task<IEnumerable<PropertyDto>> GetPropertiesByOwner(Guid ownerId)
    {
        var properties = await propertyService.GetPropertiesByOwner(new OwnerId(ownerId));
        return mapper.Map<IEnumerable<PropertyDto>>(properties);
    }
}