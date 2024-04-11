using Domain.Aggregates;
using Domain.ValueObjects;
using Havenly.Contracts.Properties;

namespace Havenly.Application.Properties;

public interface IPropertyService
{
    Task<Property?> GetProperty(PropertyId id);
    Task<IEnumerable<Property>> GetAllProperties();
    Task<IEnumerable<Property>> GetPropertiesByOwner(OwnerId ownerId);
    Task<PropertyId> ListProperty(Property property);
    Task<PropertyId> UpdateProperty(Property property);
    Task<PropertyId> DelistProperty(PropertyId id);
}