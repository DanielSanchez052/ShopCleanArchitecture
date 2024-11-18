namespace Shop.Application.Interfaces;

public interface IReadRepository<T>
{
    Task<T?> GetByInt(int id);
    Task<T?> GetByString(string id);
    Task<IEnumerable<T>> GetAllAsync();
}
