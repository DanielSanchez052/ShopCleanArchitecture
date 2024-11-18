namespace Shop.Entities.Ordering;

public class OrderStatus
{
    public OrderStatus(string name, bool isActive)
    {
        Name = name;
        IsActive = isActive;
    }

    public OrderStatus()
    {
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsActive { get; set; }

    private readonly List<Order> _orders = new List<Order>();


    public virtual IReadOnlyCollection<Order> Orders => _orders;
}
