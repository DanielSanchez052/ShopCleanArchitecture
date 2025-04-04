﻿using Shop.Application.Specifications;
using Shop.Entities.Catalog;
namespace Shop.Application.Catalog.Specifications;

public class GetProgramProductSpecification : BaseSpecification<ProgramProduct>
{
    public GetProgramProductSpecification(int programId, ProgramProductFilterParams filters)
        : base(x => x.ProgramId == programId
            && ( string.IsNullOrEmpty(filters.Segment) || (!string.IsNullOrEmpty(x.Segment) && x.Segment.Contains(filters.Segment, StringComparison.OrdinalIgnoreCase))
            && ( string.IsNullOrEmpty(filters.Name) || x.Name.Contains(filters.Name, StringComparison.OrdinalIgnoreCase))
            && ( string.IsNullOrEmpty(filters.NominalValue) || x.NominalValue == x.NominalValue)
            && (filters.ProductTypeId == null || x.Product.ProductTypeId == filters.ProductTypeId)
            && (filters.CategoryId == null || x.CategoryId == filters.CategoryId))
            && x.IsActive)
    {
        AddInclude(x => x.Product);
        AddInclude(x => x.Program.PaymentRules);
        AddInclude(x => x.Product.ProductType);
        AddInclude(x => x.ProductImages);
        AddInclude(x => x.ProgramProductReferences);
        AddInclude(x => x.Category);

        ApplyPaging(filters.PageSize * (filters.PageIndex - 1), filters.PageSize);
    }

    public GetProgramProductSpecification(int programId, string productCode)
        : base(x => x.ProgramId == programId && x.Product.ProductCode == productCode && x.IsActive)
    {
        AddInclude(x => x.Product);
        AddInclude(x => x.Product.ProductType);
        AddInclude(x => x.ProductImages);
        AddInclude(x => x.ProgramProductReferences);
        AddInclude(x => x.Category);
    }


}


public class GetProgramProductSpecificationCount : BaseSpecification<ProgramProduct>
{
    public GetProgramProductSpecificationCount(int programId, ProgramProductFilterParams filters)
        : base(x => x.ProgramId == programId
            && (string.IsNullOrEmpty(filters.Segment) || (!string.IsNullOrEmpty(x.Segment) && x.Segment.Contains(filters.Segment, StringComparison.OrdinalIgnoreCase))
            && (string.IsNullOrEmpty(filters.Name) || x.Name.Contains(filters.Name, StringComparison.OrdinalIgnoreCase))
            && (string.IsNullOrEmpty(filters.NominalValue) || x.NominalValue == x.NominalValue)
            && (filters.ProductTypeId == null || x.Product.ProductTypeId == filters.ProductTypeId)
            && (filters.CategoryId == null || x.CategoryId == filters.CategoryId)
            && (!filters.ShowWithoutInventory && x.ProgramProductReferences.Any(x => x.Available > 0)))
            && x.IsActive)
    {
    }

}


public class GetProductByGuidSpecification : BaseSpecification<ProgramProduct>
{
    public GetProductByGuidSpecification(string productGuid, int programId) : base(x => x.Product.Guid == productGuid && x.ProgramId == programId && x.IsActive)
    {
        AddInclude(x => x.Product);
        AddInclude(x => x.Product.ProductType);
        AddInclude(x => x.Program.PaymentRules);
        AddInclude(x => x.ProductImages);
        AddInclude(x => x.ProgramProductReferences);
        AddInclude(x => x.Category);
    }
}