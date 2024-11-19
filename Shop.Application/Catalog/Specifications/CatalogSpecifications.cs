using Shop.Application.Specifications;
using Shop.Entities.Catalog;

namespace Shop.Application.Catalog.Specifications;

public class CatalogProductSpecification : BaseSpecification<Product>
{
    public CatalogProductSpecification(string productCode)
        : base (p => p.ProductCode == productCode && p.IsActive)
    {
    }
}


public class GetProductsByFilterSpecification : BaseSpecification<Product>
{
    public GetProductsByFilterSpecification(ProductFilterParams filter)
        : base ( x => (string.IsNullOrEmpty(filter.Name) || x.Name.Contains(filter.Name, StringComparison.OrdinalIgnoreCase))
            && (string.IsNullOrEmpty(filter.NominalValue) || x.NominalValue == x.NominalValue)
            && (filter.ProductTypeId == null || x.ProductTypeId == filter.ProductTypeId)
            && (filter.CategoryId == null || x.CategoryId == filter.CategoryId)
        )
    {
        ApplyPaging(filter.PageSize * (filter.PageIndex - 1), filter.PageSize);
    }
}

public class GetProductsByFilterCountSpecification : BaseSpecification<Product>
{
    public GetProductsByFilterCountSpecification(ProductFilterParams filter)
        : base(x => (string.IsNullOrEmpty(filter.Name) || x.Name.Contains(filter.Name, StringComparison.OrdinalIgnoreCase))
            && (string.IsNullOrEmpty(filter.NominalValue) || x.NominalValue == x.NominalValue)
            && (filter.ProductTypeId == null || x.ProductTypeId == filter.ProductTypeId)
            && (filter.CategoryId == null || x.CategoryId == filter.CategoryId)
        )
    {
    }
}