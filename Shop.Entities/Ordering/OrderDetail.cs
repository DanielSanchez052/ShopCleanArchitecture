using Shop.Entities.Catalog;

namespace Shop.Entities.Ordering;

public class OrderDetail
{
    public OrderDetail()
    {
    }

    public OrderDetail(int orderDetailStatusId, string productReferenceGuid, int quantity, decimal unitPrice)
    {
        Guid = System.Guid.NewGuid().ToString();
        OrderDetailStatusId = orderDetailStatusId;
        ProductReferenceGuid = productReferenceGuid;
        Quantity = quantity;
        UnitPrice = unitPrice;
        CreateDate = DateTime.Now;
        UpdateDate = null;
    }

    public string Guid { get; private set; } = null!;
    public int OrderDetailStatusId { get; private set; }
    public OrderDetailStatus OrderDetailStatus { get; private set; } = null!;
    public string OrderId { get; private set; } = null!;
    public Order Order { get; private set; } = null!;
    public string ProductReferenceGuid { get; private set; } = null!;
    public ProgramProductReference ProgramProductReference { get; private set; } = null!;
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal Discount { get; private set; }
    public DateTime CreateDate { get; private set; }
    public DateTime? UpdateDate { get; private set; }

    private readonly List<OrderChangeHistory> _changeHistory = new List<OrderChangeHistory>();
    public virtual IReadOnlyCollection<OrderChangeHistory> ChangeHistory => _changeHistory;

    public static OrderDetail Create(int statusId, string productReferenceGuid, int quantity, decimal unitPrice)
    {
        var detail = new OrderDetail(statusId, productReferenceGuid, quantity, unitPrice);
        return detail;
    }


    public void SetOrderId(string orderId)
    {
        OrderId = orderId;
    }

    public void SetDiscount(decimal discount)
    {
        Discount = discount;
    }
}
