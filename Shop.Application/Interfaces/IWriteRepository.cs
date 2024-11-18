namespace Shop.Application.Interfaces;

public interface IWriteRepository<T>
{
    Task<int> AddAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> DeleteAsync(T entity);
}
