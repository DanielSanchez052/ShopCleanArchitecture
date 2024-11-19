using Shop.Application.Specifications;
using Shop.Entities.Catalog;

namespace Shop.Application.Catalog.Specifications;
public class GetCategoriesSpecification : BaseSpecification<Category>
{
    public GetCategoriesSpecification(int programId) : base(x => x.ProgramId == programId && x.IsActive)
    {
    }
}
