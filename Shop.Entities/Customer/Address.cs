using Shop.Entities.Ordering;

namespace Shop.Entities.Customer;

public class Address
{
    private readonly List<Order> _orders = new List<Order>();

    public Address()
    {
    }

    public Address(int id, string accountGuid, string? rawValue, string? street, string? city, string? state, string? country, string? zipCode, string? houseNumber, bool isDefault, bool isActive)
    {
        Id = id;
        AccountGuid = accountGuid;
        RawValue = rawValue;
        Street = street;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
        HouseNumber = houseNumber;
        IsDefault = isDefault;
        IsActive = isActive;
    }

    public int Id { get; set; }
    public string AccountGuid { get; set; } = null!;
    public Account Account { get; set; } = null!;
    public string? RawValue { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? ZipCode { get; set; }
    public string? HouseNumber { get; set; }
    public bool IsDefault { get; set; }
    public bool IsActive { get; set; }

    public virtual IReadOnlyCollection<Order> Orders => _orders;
}
