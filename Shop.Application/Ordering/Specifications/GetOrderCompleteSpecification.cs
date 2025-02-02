using Shop.Application.Specifications;
using Shop.Entities.Ordering;

namespace Shop.Application.Ordering.Specifications;

public class GetOrderCompleteByFilterSpecification : BaseSpecification<Order>
{
    public GetOrderCompleteByFilterSpecification(OrderHistoryFilterParams filters, string accountId, int programId)
        : base(o => o.AccountGuid == accountId && o.Account.ProgramId == programId
            && (filters.StatusId == null || o.StatusId == filters.StatusId)
        )
    {
        AddInclude(a => a.Account);
        AddInclude(s => s.Status);
        AddInclude(p => p.PaymentType);
        AddInclude(o => o.OrderDetails);
        AddInclude("OrderDetails.ProgramProductReference.ProgramProduct.ProductImages");
        WithTracking = false;
        ApplyPaging(filters.PageSize * ( filters.PageIndex-1 ), filters.PageSize);
    }
}


public class GetOrderCompleteCountByFilterSpecification : BaseSpecification<Order>
{
    public GetOrderCompleteCountByFilterSpecification(OrderHistoryFilterParams filters, string accountId, int programId)
        : base(o => o.AccountGuid == accountId && o.Account.ProgramId == programId
            && (filters.StatusId == null || o.StatusId == filters.StatusId)
        )
    {
        AddInclude(a => a.Account);
    }
}


