using Shop.Entities.Catalog;

namespace Shop.Infrastructure.Catalog.ViewModel;

public class CategoryViewModel
{
    public CategoryViewModel(Category entity)
    {
        Id = entity.Id;
        Name = entity.Name;
        Description = entity.Description;
        ImageUrl = entity.ImageUrl;
        ProgramId = entity.ProgramId;
        Parent = entity.Parent != null ? new CategoryViewModel(entity) : null;
        IsActive = entity.IsActive;
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public int ProgramId { get; set; }
    public CategoryViewModel? Parent { get; set; }
    public bool IsActive { get; set; }
}
