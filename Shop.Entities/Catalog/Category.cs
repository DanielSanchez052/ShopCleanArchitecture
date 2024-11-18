using Shop.Entities.Config;

namespace Shop.Entities.Catalog;

public class Category
{
    public Category(int id, string name, string? description, string? imageUrl, int programId, int? parentId, bool isActive)
    {
        Id = id;
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
        ProgramId = programId;
        ParentId = parentId;
        IsActive = isActive;
    }

    public Category()
    {
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public int ProgramId { get; set; }
    public Program Program { get; set; } = null!;
    public int? ParentId { get; set; }
    public Category? Parent { get; set; } 
    public bool IsActive { get; set; }

    private readonly List<Category> _childCategories = new List<Category>();
    public virtual IReadOnlyCollection<Category> ChildCategories => _childCategories;

    private readonly List<Product> _products = new List<Product>();
    public virtual IReadOnlyCollection<Product> Products => _products;

    private readonly List<ProgramProduct> _programProducts = new List<ProgramProduct>();

    public virtual IReadOnlyCollection<ProgramProduct> ProgramProducts => _programProducts;

}
