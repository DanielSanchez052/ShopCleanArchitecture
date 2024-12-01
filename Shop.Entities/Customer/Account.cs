using Shop.Entities.Ordering;

namespace Shop.Entities.Customer;

public class Account
{
    private readonly List<Address> _addresses = new List<Address>();
    private readonly List<Order> _orders = new List<Order>();


    public string Guid { get; set; } = null!;
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public DateTime CreateDate { get; set; }
    public bool IsActive { get; set; }

    public virtual IReadOnlyCollection<Address> Addresses => _addresses;
    public virtual IReadOnlyCollection<Order> Orders => _orders;

    public void AddAddress(Address address) => _addresses.Add(address);

    public void AddAdresses(IEnumerable<Address> addresses) => _addresses.AddRange(addresses);

}
