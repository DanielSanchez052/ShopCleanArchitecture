using Shop.Application.Interfaces;
using Shop.Entities.Catalog;
using Shop.Infrastructure.Catalog.ViewModel;

namespace Shop.Infrastructure.Catalog.Presenter;

public class ProductTypePresenter : IPresenter<ProductType, ProductTypeViewModel>
{
    public ProductTypeViewModel? Present(ProductType? entity)
     => entity != null ? new ProductTypeViewModel()
     {
         Id = entity.Id,
         Name = entity.Name,
         IsActive = entity.IsActive
     } : null;

    public IEnumerable<ProductTypeViewModel?> PresentCollection(IEnumerable<ProductType> entities)
    {
        return entities.Select(Present).Where(x => x != null);
    }
}
