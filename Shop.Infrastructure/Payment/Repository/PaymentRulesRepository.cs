using Shop.Application.Interfaces;
using Shop.Entities.Payment;
using Shop.Infrastructure.Persistence;

namespace Shop.Infrastructure.Payment.Repository;

public class PaymentRulesRepository : BaseRepository<PaymentRules>, IRepository<PaymentRules>
{
    public PaymentRulesRepository(IDbContext dbContext) : base(dbContext)
    {
    }
}
