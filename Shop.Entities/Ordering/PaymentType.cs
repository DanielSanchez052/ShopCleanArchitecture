namespace Shop.Entities.Ordering;

public class PaymentType
{
    public PaymentType(string name, string? description, string provider, string? config, bool isActive)
    {
        Name = name;
        Description = description;
        Provider = provider;
        Config = config;
        IsActive = isActive;
    }

    public PaymentType()
    {
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public string Provider { get; set; } = null!;
    public string? Config { get; set; } 
    public bool IsActive { get; set; }

    private readonly List<Order> _orders = new List<Order>();


    public virtual IReadOnlyCollection<Order> Orders => _orders;
}
