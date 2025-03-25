using Shop.Application.Specifications;
using Shop.Entities.Ordering;

namespace Shop.Application.Ordering.Specifications;

public class GetOrderSpecification : BaseSpecification<Order>
{
    public GetOrderSpecification(string orderNumber, int programId)
        : base(o => o.Id == orderNumber)
    {

    }
}
