using Shop.Entities.Catalog;

namespace Shop.Entities.Ordering;

public class OrderDetail
{
    public string Guid { get; set; } = null!;
    public int OrderDetailStatusId { get; set; }
    public OrderDetailStatus OrderDetailStatus { get; set; } = null!;
    public string OrderId { get; set; } = null!;
    public Order Order { get; set; } = null!;
    public string ProductReferenceGuid { get; set; } = null!;
    public ProgramProductReference ProgramProductReference { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }

    private readonly List<OrderChangeHistory> _changeHistory = new List<OrderChangeHistory>();
    public virtual IReadOnlyCollection<OrderChangeHistory> ChangeHistory => _changeHistory;
}
