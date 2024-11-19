using Shop.Application.Interfaces;
using Shop.Entities.Catalog;
using Shop.Infrastructure.Persistence;

namespace Shop.Infrastructure.Catalog.Repository;

public class CategoryRepository : BaseRepository<Category>, IRepository<Category>
{
    public CategoryRepository(IDbContext dbContext) : base(dbContext)
    {
    }
}
