using Domain.Entities;

namespace Havenly.Application.Amenities;

public interface IAmenityService
{
    Task<Guid> Add(string name);
    Task<IEnumerable<Amenity>> GetAll();
}