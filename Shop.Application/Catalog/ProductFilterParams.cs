namespace Shop.Application.Catalog;

public class ProductFilterParams : PagedListParams
{
    public string? Name { get; set; }
    public string? NominalValue { get; set; }
    public int? ProductTypeId { get; set; }
    public int? CategoryId { get; set; }
}

