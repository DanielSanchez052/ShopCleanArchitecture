using Shop.Application.Interfaces;
using Shop.Entities.ShopCart;
using Shop.Infrastructure.Persistence;

namespace Shop.Infrastructure.ShopCart.Repository;

public class CartitemRepository : BaseRepository<CartItem>, IRepository<CartItem>
{
    public CartitemRepository(IDbContext dbContext) : base(dbContext)
    {
    }

}
