using Shop.Entities.Catalog;

namespace Shop.Infrastructure.Catalog.ViewModel;

public class ProductImageViewModel
{
    public ProductImageViewModel(ProductImage entity)
    {
        Name = entity.Name;
        ImageUrl = string.Format("{0}/{1}", entity.BaseUrl ?? "", entity.ImageUrl);
        IsSmall = entity.IsSmall;
    }

    public string Name { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public bool IsSmall { get; set; }
}
