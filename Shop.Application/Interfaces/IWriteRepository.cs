using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Shop.Application.Interfaces;

public interface IWriteRepository<T> where T : class
{
    ValueTask<EntityEntry<T>> AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<int> DeleteBySpecificationAsync(ISpecification<T> spec);
}
