using Domain.Aggregates;
using Domain.Entities;
using Domain.ValueObjects;
using Havenly.Contracts.Amenity;
using Havenly.Contracts.Owners;
using Havenly.Contracts.Properties;
using Havenly.Contracts.Users;
using Mapster;

namespace Havenly.Api.Common.Mapping;

public class PropertyMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Property, PropertyDto>()
            .MapWith(src => new PropertyDto
            {
                Id = src.Id.Value,
                Street = src.Address.Street,
                ZipCode = src.Address.ZipCode,
                City = src.Address.ZipCode,
                Country = src.Address.Country,
                Amenities = src.Amenities.Adapt<List<AmenityDto>>(),
                OwnerId = src.OwnerId.Value,
                RentalPrice = src.RentalPrice,
                Price = src.Price,
                SquareFootage = src.SquareFootage,
                Bathrooms = src.Bathrooms,
                Bedrooms = src.Bedrooms,
                Type = src.Type,
            });

        config.NewConfig<PropertyDto, Property>().MapWith(src => new Property
        {
            Id = new PropertyId(src.Id),
            Address = new Address(src.Street, src.City, src.ZipCode, src.Country),
            Amenities = src.Amenities.Adapt<List<Amenity>>(),
            OwnerId = new OwnerId(src.OwnerId),
            Price = src.Price,
            RentalPrice = src.RentalPrice,
            SquareFootage = src.SquareFootage,
            Bathrooms = src.Bathrooms,
            Bedrooms = src.Bedrooms,
            Type = src.Type,
        });
    }
}