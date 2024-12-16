using Shop.Application.Interfaces;
using Shop.Entities.Config;

namespace Shop.Infrastructure.Config.Presenter;

public class ProgramContextPresenter : IPresenter<Program, ProgramContext>
{
    public ProgramContext? Present(Program? entity)
    {
        if(entity == null) return null;

        return new ProgramContext(entity.Id, entity.Name, entity.Slug, entity.StartDate, entity.EndDate);
    }

    public IEnumerable<ProgramContext> PresentCollection(IEnumerable<Program> entities)
    {
        return entities.Select(Present).Where(x => x != null)!;
    }
}
