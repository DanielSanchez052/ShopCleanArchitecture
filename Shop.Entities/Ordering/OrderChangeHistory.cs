namespace Shop.Entities.Ordering;

public class OrderChangeHistory
{
    public OrderChangeHistory()
    {
        Guid = System.Guid.NewGuid().ToString();    
    }

    protected OrderChangeHistory(string? orderGuid, string? orderDetailGuid, int statusId, int? paymentTypeId, string source)
    {
        Guid = System.Guid.NewGuid().ToString();
        OrderGuid = orderGuid;
        OrderDetailGuid = orderDetailGuid;
        StatusId = statusId;
        PaymentTypeId = paymentTypeId;
        CreateDate = DateTime.Now;
        Source = source;
    }

    public string Guid { get; private set; } = null!;
    public string? OrderGuid { get; private set; }
    public Order? Order { get; private set; }
    public string? OrderDetailGuid { get; private set; }
    public OrderDetail? OrderDetail { get; private set; }
    public int StatusId { get; private set; }
    public int? PaymentTypeId { get; private set; }
    public string Source { get; private set; }
    public DateTime CreateDate { get; private set; }
    
    public OrderChangeHistoryType Type()
    {
        if (string.IsNullOrEmpty(OrderGuid))
            return OrderChangeHistoryType.Order;
        else if (string.IsNullOrEmpty(OrderDetailGuid))
            return OrderChangeHistoryType.OrderDetail;
        else
            return OrderChangeHistoryType.Unknown;
    }

    public static OrderChangeHistory CreateOrderHistory(string orderGuid, int statusId, int? paymentTypeId, string source)
    {
        return new OrderChangeHistory(orderGuid, null, statusId, paymentTypeId, source);
    }

    public static OrderChangeHistory CreateOrderDetailHistory(string orderDetailGuid, int statusId, int? paymentTypeId, string source)
    {
        return new OrderChangeHistory(null, orderDetailGuid, statusId, null, source);
    }
}
