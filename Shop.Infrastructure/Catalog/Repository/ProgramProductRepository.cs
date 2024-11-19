using Shop.Application.Interfaces;
using Shop.Entities.Catalog;
using Shop.Infrastructure.Persistence;

namespace Shop.Infrastructure.Catalog.Repository;

public class ProgramProductRepository : BaseRepository<ProgramProduct>, IRepository<ProgramProduct>
{
    public ProgramProductRepository(IDbContext dbContext) : base(dbContext)
    {
    }
}
