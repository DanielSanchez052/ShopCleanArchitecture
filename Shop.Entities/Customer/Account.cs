using Shop.Entities.Config;
using Shop.Entities.Ordering;
using Shop.Entities.ShopCart;

namespace Shop.Entities.Customer;

public class Account
{
    private readonly List<Address> _addresses = new List<Address>();
    private readonly List<Order> _orders = new List<Order>();
    private readonly List<Cart> _carts = new List<Cart>();

    public string Guid { get; set; } = null!;
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public DateTime CreateDate { get; set; }
    public bool IsActive { get; set; }

    public int ProgramId { get; set; }
    public Program Program { get; set; }
    public virtual IReadOnlyCollection<Address> Addresses => _addresses;
    public virtual IReadOnlyCollection<Cart> Carts => _carts;
    public virtual IReadOnlyCollection<Order> Orders => _orders;

    public void AddAddress(Address address) => _addresses.Add(address);
    public void AddAdresses(IEnumerable<Address> addresses) => _addresses.AddRange(addresses);

}
