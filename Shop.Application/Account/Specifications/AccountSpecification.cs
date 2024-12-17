using Shop.Application.Specifications;

namespace Shop.Application.Account.Specifications;

public class GetAccountByIdSpecification : BaseSpecification<Entities.Customer.Account>
{
    public GetAccountByIdSpecification(string accountId, int programId) : base(x => x.Guid == accountId && x.ProgramId == programId)
    {
        AddInclude(x => x.Addresses);
    }
}
