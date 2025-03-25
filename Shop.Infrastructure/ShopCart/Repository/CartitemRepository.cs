using Shop.Application.Interfaces;
using Shop.Entities.ShopCart;
using Shop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Shop.Infrastructure.ShopCart.Repository;

public class CartRepository : BaseRepository<Cart>, IRepository<Cart>
{
    public CartRepository(IDbContext dbContext) : base(dbContext)
    {
    }

    //public List<Cart> GetActiveCarts(string accountGuid, int programId)
    //{
    //    var query = DbContext.Set<Cart>()
    //            .Include(x => x.CartItems)
    //            .Where(x => x.AccountGuid == accountGuid && x.Account.ProgramId == programId && x.IsActive);
    //    return query.ToList();
    //}

}
