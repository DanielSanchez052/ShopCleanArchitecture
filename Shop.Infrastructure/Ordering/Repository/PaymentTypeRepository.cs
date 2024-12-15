using Shop.Application.Interfaces;
using Shop.Entities.Ordering;
using Shop.Infrastructure.Persistence;

namespace Shop.Infrastructure.Ordering.Repository;

public class PaymentTypeRepository : BaseRepository<PaymentType>, IRepository<PaymentType>
{
    public PaymentTypeRepository(IDbContext dbContext) : base(dbContext)
    {
    }
}
