using Shop.Application.Specifications;
using Shop.Entities.Payment;

namespace Shop.Application.Payment.Specifications;

public class GetActivePaymentTypesSpecification : BaseSpecification<PaymentType>
{
    public GetActivePaymentTypesSpecification()
        : base(x => x.IsActive)
    {
    }
}