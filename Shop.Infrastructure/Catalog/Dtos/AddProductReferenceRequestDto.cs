namespace Shop.Infrastructure.Catalog.Dtos;

public class AddProductReferenceRequestDto
{
    public string ProgramProductGuid { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? AditionalData { get; set; }
    public int Inventory { get; set; }
    public int Available { get; set; }
    public bool IsActive { get; set; }
}
