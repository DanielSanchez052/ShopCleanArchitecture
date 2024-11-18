namespace Shop.Entities.Ordering;

public class OrderDetailStatus
{
    public OrderDetailStatus(string name, bool isActive)
    {
        Name = name;
        IsActive = isActive;
    }

    public OrderDetailStatus()
    {
    }
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsActive { get; set; }

    private readonly List<OrderDetail> _orderDetails = new List<OrderDetail>();
    public virtual IReadOnlyCollection<OrderDetail> OrderDetails => _orderDetails;
}
