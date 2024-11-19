using Shop.Application.Interfaces;
using Shop.Entities.Catalog;
using Shop.Infrastructure.Catalog.ViewModel;

namespace Shop.Infrastructure.Catalog.Presenter;

public class CategoryPresenter : IPresenter<Category, CategoryViewModel>
{
    public CategoryViewModel? Present(Category? entity)
    {
        return entity != null ? new CategoryViewModel(entity) : null;
    }

    public IEnumerable<CategoryViewModel> PresentCollection(IEnumerable<Category> entities)
    {
        if(entities == null || entities.Count() == 0)
        {
            return new List<CategoryViewModel>();
        }

        return entities.Select(Present);
    }
}
