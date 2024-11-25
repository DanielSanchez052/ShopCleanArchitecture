namespace Shop.Infrastructure.Catalog.Dtos;

public class AddProductRequestDto
{
    public string ProductCode { get; set; } = null!;
    public int ProductTypeId { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; } = null!;
    public string ShortDescription { get; set; } = null!;
    public string? LongDescription { get; set; }
    public string? Terms { get; set; }
    public string? Conditions { get; set; }
    public string? Instructions { get; set; }
    public string? NominalValue { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsActive { get; set; }
}
