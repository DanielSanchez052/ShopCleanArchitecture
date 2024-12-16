using Shop.Application.Specifications;
using Shop.Entities.Payment;

namespace Shop.Application.Payment.Specifications;

public class GetActivePaymentRuleSpecification : BaseSpecification<PaymentRules>
{
    public GetActivePaymentRuleSpecification(int programId)
        : base(x => x.ProgramId == programId && x.IsActive)
    {
    }
}
