using Domain.Enums;
using Havenly.Contracts.Amenity;
using Havenly.Contracts.Owners;

namespace Havenly.Contracts.Properties;

public class PropertyDto
{
    public Guid Id { get; set; }
    public PropertyType Type { get; set; }
    public string Name { get; set; }
    public string Street { get; set; }
    public string Zip { get; set; }
    public string City { get; set; }
    public int Bedrooms { get; set; }
    public int Bathrooms { get; set; }
    public int SquareFootage { get; set; }
    public int Price { get; set; }
    public Guid OwnerId { get; set; }
    public OwnerDto Owner { get; set; }
    public List<AmenityDto> Amenities { get; set; }
}