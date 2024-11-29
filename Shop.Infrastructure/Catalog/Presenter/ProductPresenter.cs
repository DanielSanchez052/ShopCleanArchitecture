using Shop.Application.Interfaces;
using Shop.Entities.Catalog;
using Shop.Infrastructure.Catalog.ViewModel;

namespace Shop.Infrastructure.Catalog.Presenter;

public class ProductPresenter : IPresenter<Product, ProductViewModel>
{
    public ProductViewModel? Present(Product? entity)
    {
        if(entity == null) return null;

        return new ProductViewModel() 
        { 
            ProductGuid = entity.Guid,
            ProductCode = entity.ProductCode,
            Name = entity.Name,
            ProductType = entity.ProductTypeId,
            ShortDescription = entity.ShortDescription,
            LongDescription = entity.LongDescription,
            Terms = entity.Terms,
            Conditions = entity.Conditions,
            Instructions = entity.Instructions,
            NominalValue = entity.NominalValue,
            ImageUrl = entity.ImageUrl,
            Category = entity.CategoryId,
            IsActive = entity.IsActive,
        };
    }

    public IEnumerable<ProductViewModel?> PresentCollection(IEnumerable<Product> entities)
    {
        return entities.Select(Present);
    }
}
