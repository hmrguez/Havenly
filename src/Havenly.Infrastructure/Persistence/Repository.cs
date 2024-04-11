using Domain.Common.Models;
using Havenly.Application.Common.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Havenly.Infrastructure.Persistence;

public class Repository<T, TId> : IRepository<T, TId> where T : Entity<TId> where TId : notnull
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

    public Repository(IDbContextFactory<ApplicationDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<T?> GetById(TId id, params string[] includes)
    {
        using var context = _contextFactory.CreateDbContext();
        var query = context.Set<T>().AsQueryable();
        query = includes.Aggregate(query, (current, include) => current.Include(include));
        
        return await query.FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public async Task<T?> GetByProperty<TProp>(Func<T, TProp> property, TProp value)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return context.Set<T>().AsEnumerable()
            .FirstOrDefault(x => EqualityComparer<TProp>.Default.Equals(property(x), value));
    }

    public async Task<IEnumerable<T>> GetAll(Func<T, bool>? predicate = null)
    {
        using var context = _contextFactory.CreateDbContext();
        return predicate == null ? await context.Set<T>().ToListAsync() : context.Set<T>().Where(predicate).ToList();
    }

    public async Task Add(T entity)
    {
        using var context = _contextFactory.CreateDbContext();
        context.Set<T>().Add(entity);
        await context.SaveChangesAsync();
    }

    public async Task Update(T entity)
    {
        using var context = _contextFactory.CreateDbContext();
        context.Set<T>().Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
        using var context = _contextFactory.CreateDbContext();
        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
    }
}