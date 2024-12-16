namespace Shop.Infrastructure.Catalog.ViewModel;

public class ProgramProductViewModel
{
    public string Guid { get; set; } = null!;
    public string ProductCode { get; set; } = null!;
    public int ProgramId { get; set; }
    public string Name { get; set; }
    public string ShortDescription { get; set; } = null!;
    public string? LongDescription { get; set; }
    public string? Terms { get; set; }
    public string? Conditions { get; set; }
    public string? Instructions { get; set; }
    public string? NominalValue { get; set; }
    public string? Segment { get; set; }
    public decimal BasePrice { get; set; }
    public decimal Iva { get; set; }
    public decimal BaseCost { get; set; }
    public decimal Price { get; set; }
    public int PointValue { get; set; }
    public int ProductTypeId { get; set; }
    public string ProductTypeName { get; set; } = null!;
    public List<ProductReferenceViewModel> References { get; set; } = new();
    public CategoryViewModel? Category { get; set; }
    public List<ProductImageViewModel> ProductImages { get; set; } = new();
    public bool IsActive { get; set; }
}
