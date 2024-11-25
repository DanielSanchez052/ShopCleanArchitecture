using Shop.Application.Interfaces;
using Shop.Entities.Config;
using Shop.Infrastructure.Persistence;

namespace Shop.Infrastructure.Config.Repository;

public class ProgramRepository : BaseRepository<Program>, IRepository<Program>
{
    public ProgramRepository(IDbContext dbContext) : base(dbContext)
    {
    }
}
