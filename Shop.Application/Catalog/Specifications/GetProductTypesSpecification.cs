using Shop.Application.Specifications;
using Shop.Entities.Catalog;

namespace Shop.Application.Catalog.Specifications;

public class GetProductTypesSpecification : BaseSpecification<ProductType>
{
    public GetProductTypesSpecification() : base(x => x.IsActive)
    {
    }
}
