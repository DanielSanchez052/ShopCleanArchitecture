using Shop.Application.Interfaces;
using Shop.Entities.Customer;
using Shop.Infrastructure.Persistence;

namespace Shop.Infrastructure.Customer.Repository;

public class AccountRepository : BaseRepository<Account>, IRepository<Account>
{
    public AccountRepository(IDbContext dbContext) : base(dbContext)
    {
    }
}
