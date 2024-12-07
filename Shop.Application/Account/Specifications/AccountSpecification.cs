using Shop.Application.Specifications;

namespace Shop.Application.Account.Specifications;

public class GetAccountByIdSpecification : BaseSpecification<Entities.Customer.Account>
{
    public GetAccountByIdSpecification(string accountId) : base(x => x.Guid == accountId)
    {
        AddInclude(x => x.Addresses);
    }
}
