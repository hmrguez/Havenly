using Domain.Aggregates;
using Domain.Entities;
using Domain.ValueObjects;
using Havenly.Application.Common.Interfaces.Persistence;

namespace Havenly.Application.Properties;

public class PropertyService : IPropertyService
{
    private readonly IRepository<Property, PropertyId> _propertyRepository;
    private readonly IRepository<Amenity, AmenityId> _amenityRepository;

    public PropertyService(IRepository<Property, PropertyId> propertyRepository, IRepository<Amenity, AmenityId> amenityRepository)
    {
        _propertyRepository = propertyRepository;
        _amenityRepository = amenityRepository;
    }

    public Task<Property?> GetProperty(PropertyId id)
    {
        return _propertyRepository.GetById(id, "Owner", "Amenities");
    }

    public Task<IEnumerable<Property>> GetAllProperties()
    {
        return _propertyRepository.GetAll(null, "Owner", "Amenities");
    }

    public Task<IEnumerable<Property>> GetPropertiesByOwner(OwnerId ownerId)
    {
        return _propertyRepository.GetAll(x => x.Owner.Id.Equals(ownerId), "Owner", "Amenities");
    }

    public async Task<PropertyId> ListProperty(Property property)
    {
        var newProperty = Property.Create(property.Address, property.Type, property.OwnerId, property.Owner);
        await _propertyRepository.Add(newProperty);
        return newProperty.Id;
    }

    public async Task<PropertyId> UpdateProperty(Property property)
    {
        await _propertyRepository.Update(property);
        return property.Id;
    }

    public async Task<PropertyId> DelistProperty(PropertyId id)
    {
        await _propertyRepository.Delete(id);
        return id;
    }
}