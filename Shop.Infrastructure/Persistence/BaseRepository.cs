using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shop.Application.Interfaces;

namespace Shop.Infrastructure.Persistence;

public abstract class BaseRepository<T> : 
    IReadRepository<T>,
    IWriteRepository<T> where T : class
{
    protected BaseRepository(IDbContext dbContext) => DbContext = dbContext;

    protected IDbContext DbContext { get; }

    public ValueTask<EntityEntry<T>> AddAsync(T entity)
    {
        return DbContext.Set<T>().AddAsync(entity);
    }

    public Task<int> CountAsync(ISpecification<T> spec)
    {
        return ApplySpecification(spec).CountAsync();
    }

    public void Delete(T entity)
    {
        DbContext.Set<T>().Remove(entity);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await DbContext.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByInt(int id)
    {
         return await DbContext.Set<T>().FindAsync(id);
    }

    public async Task<T?> GetByString(string id)
    {
         return await DbContext.Set<T>().FindAsync(id);
    }

    public async Task<T?> GetEntityWithSpec(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync();

    }

    public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).ToListAsync();
    }

    public void Update(T entity)
    {
        DbContext.Set<T>().Update(entity);
    }

    protected IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        return SpecificationEvaluator<T>.GetQuery(DbContext.Set<T>().AsQueryable(), spec);
    }

}
