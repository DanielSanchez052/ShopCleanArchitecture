using Shop.Application.Interfaces;
using Shop.Entities.Catalog;
using Shop.Entities.Ordering;
using Shop.Infrastructure.Persistence;

namespace Shop.Infrastructure.Ordering.Repository;

public class OrderRepository : BaseRepository<Order>, IRepository<Order>
{
    public OrderRepository(IDbContext dbContext) : base(dbContext)
    {
    }
}
