namespace Shop.Application.Interfaces;

public interface IReadRepository<T>
{
    Task<T?> GetByInt(int id);
    Task<T?> GetByString(string id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<int> CountAsync(ISpecification<T> spec);
    Task<T?> GetEntityWithSpec(ISpecification<T> spec);
    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
}
