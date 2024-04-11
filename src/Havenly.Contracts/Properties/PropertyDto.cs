using Domain.Enums;
using Domain.ValueObjects;
using Havenly.Contracts.Amenity;
using Havenly.Contracts.Owners;

namespace Havenly.Contracts.Properties;

public class PropertyDto
{
    public Guid Id { get; set; }
    public PropertyType Type { get; set; }

    public string Street { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
    
    public int Bedrooms { get; set; }
    public int Bathrooms { get; set; }
    public int SquareFootage { get; set; }
    public int Price { get; set; }
    public int RentalPrice { get; set; }
    public Guid OwnerId { get; set; }
    public OwnerDto? Owner { get; set; }
    public List<AmenityDto>? Amenities { get; set; }
}