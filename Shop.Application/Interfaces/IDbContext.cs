
using Microsoft.EntityFrameworkCore;

namespace Shop.Application.Interfaces;
public interface IDbContext
{
    DbSet<TEntity> Set<TEntity>()
            where TEntity : class;
}
