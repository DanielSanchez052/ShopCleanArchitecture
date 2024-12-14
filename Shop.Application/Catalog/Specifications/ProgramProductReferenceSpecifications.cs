using Shop.Application.Specifications;
using Shop.Entities.Catalog;

namespace Shop.Application.Catalog.Specifications;

public class GetActiveReferenceSpecification : BaseSpecification<ProgramProductReference>
{
    public GetActiveReferenceSpecification(string referenceGuid) 
        : base(x => x.Guid == referenceGuid && x.IsActive)
    {
        AddInclude(x => x.ProgramProduct);
    }
}