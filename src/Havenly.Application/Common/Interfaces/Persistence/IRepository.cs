using Domain.Common.Models;

namespace Havenly.Application.Common.Interfaces.Persistence;

public interface IRepository<T, TId> where T : Entity<TId> where TId : notnull
{
    Task<T?> GetById(TId id);
    Task<T?> GetByProperty<TProp>(Func<T, TProp> property, TProp value);
    Task<IEnumerable<T>> GetAll(Func<T, bool>? predicate = null);
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}