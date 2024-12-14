using Shop.Application.Interfaces;
using Shop.Entities.ShopCart;
using Shop.Infrastructure.Persistence;

namespace Shop.Infrastructure.ShopCart.Repository;

public class CartRepository : BaseRepository<Cart>, IRepository<Cart>
{
    public CartRepository(IDbContext dbContext) : base(dbContext)
    {
    }
}
