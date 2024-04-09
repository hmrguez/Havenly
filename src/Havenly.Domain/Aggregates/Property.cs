using Domain.Common.Models;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Aggregates;

public class Property : AggregateRoot<PropertyId>
{
    public Address Address { get; set; }
    public PropertyType Type { get; set; }

    public OwnerId OwnerId { get; set; }
    public Owner Owner { get; set; }
    public List<Amenity> Amenity { get; set; }

    private Property(PropertyId id, Address address, PropertyType type, OwnerId ownerId, Owner owner) : base(id)
    {
        Address = address;
        Type = type;
        OwnerId = ownerId;
        Owner = owner;
        Amenity = [];
    }

    public static Property Create(Address address, PropertyType type, OwnerId ownerId, Owner owner)
    {
        return new Property(PropertyId.CreateUnique(), address, type, ownerId, owner);
    }
}