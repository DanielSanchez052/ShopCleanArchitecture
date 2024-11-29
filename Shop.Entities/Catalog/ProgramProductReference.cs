using Shop.Entities.Digital;
using Shop.Entities.Ordering;

namespace Shop.Entities.Catalog;

public class ProgramProductReference
{
    public ProgramProductReference(string guid, string programProductGuid, int inventory, int available, bool isActive)
    {
        Guid = guid;
        ProgramProductGuid = programProductGuid;
        Inventory = inventory;
        Available = available;
        IsActive = isActive;
    }

    public ProgramProductReference()
    {
    }

    public string Guid { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? AditionalData { get; set; }
    public string ProgramProductGuid { get; set; } = null!;
    public ProgramProduct ProgramProduct { get; set; } = null!;
    public int Inventory { get; set; }
    public int Available { get; set; }
    public bool IsActive { get; set; }

    private readonly List<OrderDetail> _orderDetails = new List<OrderDetail>();
    public virtual IReadOnlyCollection<OrderDetail> OrderDetails => _orderDetails;

    private readonly List<Code> _codes = new List<Code>();
    public virtual IReadOnlyCollection<Code> Codes => _codes;
}
