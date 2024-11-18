namespace Shop.Infrastructure.Catalog.ViewModel;

public class ProductViewModel
{
    public string ProductCode { get; set; } = null!;
    public string Name { get; set; } = null!;
    public int ProductType { get; set; }
    public string ShortDescription { get; set; } = null!;
    public string? LongDescription { get; set; }
    public string? Terms { get; set; }
    public string? Conditions { get; set; }
    public string? Instructions { get; set; }
    public string? NominalValue { get; set; }
    public string? ImageUrl { get; set; }
    public int Category { get; set; }
    public bool IsActive { get; set; }
}
