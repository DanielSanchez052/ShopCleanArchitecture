using Shop.Entities.Config;

namespace Shop.Entities.Catalog;

public class ProgramProduct
{

    public ProgramProduct(string guid, string productGuid, int programId, string name, string shortDescription, string? longDescription, string? terms, string? conditions, string? instructions, string? nominalValue, string? segment, decimal basePrice, decimal iva, decimal baseCost, int categoryId, DateTime createDate, bool isActive)
    {
        Guid = guid;
        ProductGuid = productGuid;
        ProgramId = programId;
        Name = name;
        ShortDescription = shortDescription;
        LongDescription = longDescription;
        Terms = terms;
        Conditions = conditions;
        Instructions = instructions;
        NominalValue = nominalValue;
        Segment = segment;
        BasePrice = basePrice;
        Iva = iva;
        BaseCost = baseCost;
        CategoryId = categoryId;
        CreateDate = createDate;
        IsActive = isActive;
    }

    public ProgramProduct()
    {
    }

    public string Guid { get; set; } = null!;
    public string ProductGuid { get; set; } = null!;
    public Product Product { get; set; } = null!;
    public int ProgramId { get; set; }
    public Program Program { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string ShortDescription { get; set; } = null!;
    public string? LongDescription { get; set; }
    public string? Terms { get; set; }
    public string? Conditions { get; set; }
    public string? Instructions { get; set; }
    public string? NominalValue { get; set; }
    public string? Segment { get; set; }
    public decimal BasePrice { get; set; }
    public decimal Iva { get; set; }
    public decimal BaseCost { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public DateTime CreateDate { get; set; }
    public bool IsActive { get; set; }

    private readonly List<ProgramProductReference> _programProductReferences = new List<ProgramProductReference>();
    public virtual IReadOnlyCollection<ProgramProductReference> ProgramProductReferences => _programProductReferences;

    private readonly List<ProductImage> _productImages = new List<ProductImage>();
    public virtual IReadOnlyCollection<ProductImage> ProductImages => _productImages;

    public void AddReferences(IEnumerable<ProgramProductReference> references)
    {
        _programProductReferences.AddRange(references);
    }

}
