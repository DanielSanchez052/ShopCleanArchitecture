using Shop.Application.Interfaces;
using Shop.Entities.Payment;
using Shop.Infrastructure.Persistence;

namespace Shop.Infrastructure.Payment.Repository;

public class PaymentTypeRepository : BaseRepository<PaymentType>, IRepository<PaymentType>
{
    public PaymentTypeRepository(IDbContext dbContext) : base(dbContext)
    {
    }
}
