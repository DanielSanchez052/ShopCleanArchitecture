using Shop.Entities.Catalog;
using Shop.Entities.Ordering;

namespace Shop.Entities.Customer;

public class Account
{
    public string Guid { get; set; } = null!;
    public DateTime CreateDate { get; set; }
    public bool IsActive { get; set; }

    private readonly List<Address> _addresses = new List<Address>();
    public virtual IReadOnlyCollection<Address> Addresses => _addresses;

    private readonly List<Order> _orders = new List<Order>();
    public virtual IReadOnlyCollection<Order> Orders => _orders;
}
