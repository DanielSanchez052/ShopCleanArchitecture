namespace Shop.Entities.Catalog;

public class Product
{
    public Product(string guid, string productCode, string name, int productTypeId, string shortDescription, string? longDescription, string? terms, string? conditions, string? instructions, string? nominalValue, string? imageUrl, int categoryId, DateTime createDate, bool isActive)
    {
        Guid = guid;
        ProductCode = productCode;
        Name = name;
        ProductTypeId = productTypeId;
        ShortDescription = shortDescription;
        LongDescription = longDescription;
        Terms = terms;
        Conditions = conditions;
        Instructions = instructions;
        NominalValue = nominalValue;
        ImageUrl = imageUrl;
        CategoryId = categoryId;
        CreateDate = createDate;
        IsActive = isActive;
    }

    public Product()
    {
    }

    public string Guid { get; set; } = null!;
    public string ProductCode { get; set; } = null!;
    public string Name { get; set; } = null!;
    public int ProductTypeId { get; set; }
    public ProductType ProductType { get; set; } = null!;
    public string ShortDescription { get; set; } = null!;
    public string? LongDescription { get; set; }
    public string? Terms { get; set; }
    public string? Conditions { get; set; }
    public string? Instructions { get; set; }
    public string? NominalValue { get; set; }
    public string? ImageUrl { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public DateTime CreateDate { get; set; }
    public bool IsActive { get; set; }

    private readonly List<ProgramProduct> _programProducts = new List<ProgramProduct>();

    public virtual IReadOnlyCollection<ProgramProduct> ProgramProducts => _programProducts;
}
