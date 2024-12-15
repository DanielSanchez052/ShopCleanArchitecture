using Shop.Application.Specifications;
using Shop.Entities.Ordering;

namespace Shop.Application.Ordering.Specifications;

public class GetActivePaymentTypesSpecification : BaseSpecification<PaymentType>
{
    public GetActivePaymentTypesSpecification()
        : base(x => x.IsActive)
    {
    }
}