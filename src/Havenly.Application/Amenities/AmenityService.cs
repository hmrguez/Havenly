using Domain.Entities;
using Domain.ValueObjects;
using Havenly.Application.Common.Interfaces.Persistence;

namespace Havenly.Application.Amenities;

public class AmenityService(IRepository<Amenity, AmenityId> amenityRepository)
    : IAmenityService
{
    public async Task<Guid> Add(string name)
    {
        var amenity = Amenity.Create(name);
        await amenityRepository.Add(amenity);
        return amenity.Id.Value;
    }

    public Task<IEnumerable<Amenity>> GetAll()
    {
        return amenityRepository.GetAll();
    }
}