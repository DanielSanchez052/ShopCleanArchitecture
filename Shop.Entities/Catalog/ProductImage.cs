namespace Shop.Entities.Catalog;

public class ProductImage
{
    public string Guid { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public string? BaseUrl { get; set; }
    public bool IsSmall { get; set; }
    public string ProductGuid { get; set; } = null!;
    public ProgramProduct Product { get; set; } = null!;
    public bool IsActive { get; set; }
}
