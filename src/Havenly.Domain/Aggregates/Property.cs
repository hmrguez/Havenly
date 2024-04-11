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
    public List<Amenity> Amenities { get; set; }

    public int SquareFootage { get; set; }
    public int Bedrooms { get; set; }
    public int Bathrooms { get; set; }

    public int Price { get; set; }
    public int RentalPrice { get; set; }

    public Property()
    {
    }

    public Property(PropertyId id, Address address, PropertyType type, OwnerId ownerId, Owner owner) : base(id)
    {
        Address = address;
        Type = type;
        OwnerId = ownerId;
        Owner = owner;
        Amenities = [];
    }

    public static Property Create(Address address, PropertyType type, OwnerId ownerId, Owner owner)
    {
        return new Property(PropertyId.CreateUnique(), address, type, ownerId, owner);
    }
}