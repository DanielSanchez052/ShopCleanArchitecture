namespace Shop.Entities.Catalog;

public class ProductType
{
    public ProductType(int id, string name, ProductTypeConfig? config, bool isActive)
    {
        Id = id;
        Name = name;
        Config = config;
        IsActive = isActive;
    }

    public ProductType()
    {
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ProductTypeConfig? Config { get; set; }
    public bool IsActive { get; set; }

    private readonly List<Product> _products = new List<Product>();

    public virtual IReadOnlyCollection<Product> Products => _products;
}
