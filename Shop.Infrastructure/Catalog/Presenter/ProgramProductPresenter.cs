using Shop.Application.Interfaces;
using Shop.Entities.Catalog;
using Shop.Infrastructure.Catalog.ViewModel;

namespace Shop.Infrastructure.Catalog.Presenter;

public class ProgramProductPresenter : IPresenter<ProgramProduct, ProgramProductViewModel>
{
    public ProgramProductViewModel? Present(ProgramProduct? entity)
    {
        if(entity == null) return null;

        return new ProgramProductViewModel()
        {
            Guid = entity.Guid,
            ProductCode = entity.Product?.ProductCode ?? "",
            ProgramId = entity.ProgramId,
            Name = entity.Name,
            ShortDescription = entity.ShortDescription,
            LongDescription = entity.LongDescription,
            Terms = entity.Terms,
            Conditions = entity.Conditions,
            Instructions = entity.Instructions,
            NominalValue = entity.NominalValue,
            Segment = entity.Segment,
            BasePrice = entity.BasePrice,
            Iva = entity.Iva,
            BaseCost = entity.BaseCost,
            References = entity.ProgramProductReferences.Select(s => new ProductReferenceViewModel()
            {
                Guid = s.Guid,
                Available = s.Available,
                Inventory = s.Inventory,
            }).ToList(),
            ProductTypeId = entity.Product?.ProductTypeId ?? 0,
            ProductTypeName = entity.Product?.ProductType?.Name ?? "",
            Category = entity.Category != null ? new CategoryViewModel(entity.Category) : null,
            ProductImages = entity.ProductImages != null ? entity.ProductImages.Select(pi => new ProductImageViewModel(pi)).ToList() : new(),
            IsActive = entity.IsActive,
        };
    }

    public IEnumerable<ProgramProductViewModel?> PresentCollection(IEnumerable<ProgramProduct> entities)
    {
        return entities.Select(Present);
    }
}
