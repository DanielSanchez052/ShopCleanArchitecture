using Shop.Application.Primitives.Maybe;

namespace Shop.Application.Interfaces;

public interface IReadRepository<T>
{
    Task<Maybe<T>> GetByInt(int id);
    Task<Maybe<T>> GetByString(string id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<int> CountAsync(ISpecification<T> spec);
    Task<Maybe<T>> GetEntityWithSpec(ISpecification<T> spec);
    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
}
