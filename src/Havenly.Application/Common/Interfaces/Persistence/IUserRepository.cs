using Domain.Entities;
using Domain.ValueObjects;

namespace Havenly.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<User?> GetById(UserId id);
    Task<User?> GetByEmail(string email);
    Task Add(User user);
}