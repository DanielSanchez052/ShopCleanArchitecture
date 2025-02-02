using Shop.Application.Interfaces;
using Shop.Entities.Catalog;
using Shop.Infrastructure.Catalog.ViewModel;

namespace Shop.Infrastructure.Catalog.Presenter;

public class ProgramProductPresenter : IPresenter<ProgramProduct, ProgramProductViewModel>
{
    public ProgramProductViewModel? Present(ProgramProduct? entity)
    {
        if(entity == null) return null;

        var product = new ProgramProductViewModel()
        {
            Guid = entity.Guid,
            ProductCode = entity.Product?.ProductCode ?? "",
            ProgramId = entity.ProgramId,
            Name = entity.Name,
            ShortDescription = entity.ShortDescription,
            LongDescription = entity.LongDescription,
            Terms = entity.Terms,
            Conditions = entity.Conditions,
            PointValue = entity.PointValue ?? 0,
            Instructions = entity.Instructions,
            NominalValue = entity.NominalValue,
            Segment = entity.Segment,
            BasePrice = entity.BasePrice,
            Iva = entity.Iva,
            BaseCost = entity.BaseCost,
            Price = entity.GetPrice(),
            References = entity.ProgramProductReferences.Select(s => new ProductReferenceViewModel()
            {
                Guid = s.Guid,
                Name = s.Name,
                Description = s.Description,
                AditionalData = s.AditionalData,
                Available = s.Available,
                Inventory = s.Inventory,
            }).ToList(),
            ProductTypeId = entity.Product?.ProductTypeId ?? 0,
            ProductTypeName = entity.Product?.ProductType?.Name ?? "",
            Category = entity.Category != null ? new CategoryViewModel(entity.Category) : null,
            ProductImages = entity.ProductImages != null ? entity.ProductImages.Select(pi => new ProductImageViewModel(pi)).ToList() : new(),
            IsActive = entity.IsActive,
        };

        var rule = entity.Program?.PaymentRules.FirstOrDefault();
        if (rule != null && rule.AutoCalulated)
        {
            product.PointValue = rule.GetPointValue(entity.GetPrice());
        }

        //if(product.Price <= 0 || product.PointValue <= 0) return null;

        return product;
    }

    public IEnumerable<ProgramProductViewModel?> PresentCollection(IEnumerable<ProgramProduct> entities)
    {
        return entities.Select(Present).Where(x => x != null);
    }
}
