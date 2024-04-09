using Domain.Entities;

namespace Havenly.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<User?> GetById(Guid id);
    Task<User?> GetByEmail(string email);
    Task Add(User user);
}