using Shop.Application.Interfaces;
using Shop.Entities.Catalog;
using Shop.Infrastructure.Persistence;

namespace Shop.Infrastructure.Catalog.Repository;

public class ProgramProductReferenceRepository : BaseRepository<ProgramProductReference>, IRepository<ProgramProductReference>
{
    public ProgramProductReferenceRepository(IDbContext dbContext) : base(dbContext)
    {
    }
}
