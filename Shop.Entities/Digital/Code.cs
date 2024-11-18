using Shop.Entities.Catalog;

namespace Shop.Entities.Digital;

public class Code
{
    public string Guid { get; set; } = null!;
    public string ProductReferenceGuid { get; set; } = null!;
    public ProgramProductReference ProgramProductReference { get; set; } = null!;
    public string DigitalCode { get; set; } = null!;
    public string? Link { get; set; }
    public bool Used { get; set; }
    public DateTime UsedDate { get; set; }
    public DateTime CreateDate { get; set; }
    public int ExpirationTypeId { get; set; }
    public ExpirationType ExpirationType { get; set; } = null!;
    public string Expiration { get; set; } = null!;
    public bool IsActive { get; set; }
}
