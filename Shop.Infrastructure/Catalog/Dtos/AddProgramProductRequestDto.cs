namespace Shop.Infrastructure.Catalog.Dtos;

public class AddProgramProductRequestDto
{
    public string ProductGuid { get; set; }
    public int ProgramId { get; set; }
    public string Name { get; set; } = null!;
    public string ShortDescription { get; set; } = null!;
    public string? LongDescription { get; set; }
    public string? Terms { get; set; }
    public string? Conditions { get; set; }
    public string? Instructions { get; set; }
    public string? NominalValue { get; set; }
    public string? Segment { get; set; }
    public decimal BasePrice { get; set; }
    public int CategoryId { get; set; }
    public decimal Iva { get; set; }
    public decimal BaseCost { get; set; }
    public bool IsActive { get; set; }

}
