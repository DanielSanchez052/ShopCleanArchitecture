using Shop.Application.Interfaces;
using Shop.Entities.Catalog;
using Shop.Infrastructure.Persistence;

namespace Shop.Infrastructure.Catalog.Repository;

public class ProductTypeRepository : BaseRepository<ProductType>, IRepository<ProductType>
{
    public ProductTypeRepository(IDbContext dbContext) : base(dbContext)
    {
    }
}
