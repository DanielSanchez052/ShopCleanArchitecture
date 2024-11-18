using Shop.Entities.Accounts;

namespace Shop.Entities.Ordering;

public class Address
{
    public int Id { get; set; }
    public string AccountGuid { get; set; } = null!;
    public Account Account { get; set; } = null!;
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? ZipCode { get; set; }
    public string? HouseNumber { get; set; }
    public bool IsDefault { get; set; }
    public bool IsActive { get; set; }

    private readonly List<Order> _orders = new List<Order>();
    public virtual IReadOnlyCollection<Order> Orders => _orders;
}
