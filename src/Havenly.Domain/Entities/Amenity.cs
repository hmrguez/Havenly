using Domain.Aggregates;
using Domain.Common.Models;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Amenity : Entity<AmenityId>
{
    public string Name { get; set; }
    public ICollection<Property> Properties { get; set; }

    public Amenity()
    {
    }

    private Amenity(AmenityId id, string name) : base(id)
    {
        Name = name;
    }

    public static Amenity Create(string name)
    {
        return new Amenity(AmenityId.CreateUnique(), name);
    }
}