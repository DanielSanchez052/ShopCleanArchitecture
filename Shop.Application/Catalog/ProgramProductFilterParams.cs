namespace Shop.Application.Catalog;

public class ProgramProductFilterParams : PagedListParams
{
    public string? Segment { get; set; }
    public string? Name { get; set; }
    public string? NominalValue { get; set; }
    public int ProgramId { get; set; }
    public int? ProductTypeId { get; set; }
    public int? CategoryId { get; set; }
    public bool ShowWithoutInventory { get; set; }
    public string? OrderByColumn { get; set; }
    public string? OrderByType { get; set; }
}
