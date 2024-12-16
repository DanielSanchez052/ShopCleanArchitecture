using Shop.Application.Specifications;

namespace Shop.Application.Config.Specifications;

public class GetProgramBySlugSpecification : BaseSpecification<Entities.Config.Program>
{
    public GetProgramBySlugSpecification(string slug)
        : base(x => x.Slug == slug)
    {

    }
}



