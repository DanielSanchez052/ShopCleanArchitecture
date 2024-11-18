namespace Shop.Infrastructure.Catalog.ViewModel;

public class CategoryViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public int ProgramId { get; set; }
    public int? ParentId { get; set; }
    public CategoryViewModel? Parent { get; set; }
    public bool IsActive { get; set; }
}
