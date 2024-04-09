using Domain.Entities;
using Havenly.Application.Common.Interfaces.Persistence;

namespace Havenly.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users = [];

    public async Task<User?> GetById(Guid id)
    {
        await Task.CompletedTask;
        return _users.FirstOrDefault(x => x.Id == id);
    }

    public async Task<User?> GetByEmail(string email)
    {
        await Task.CompletedTask;
        return _users.FirstOrDefault(x => x.Email == email);
    }

    public async Task Add(User user)
    {
        await Task.CompletedTask;
        _users.Add(user);
    }
}