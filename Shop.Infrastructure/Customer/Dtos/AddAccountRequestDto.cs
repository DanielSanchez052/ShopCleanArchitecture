namespace Shop.Infrastructure.Customer.Dtos;

public class AddAccountRequestDto
{
    public string Id { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public bool IsActive { get; set; }
    public List<AddressModel> Addresses { get; set; } = new List<AddressModel>();
}

public class AddressModel
{
    public string? RawValue { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? ZipCode { get; set; }
    public string? HouseNumber { get; set; }
    public bool IsDefault { get; set; }
    public bool IsActive { get; set; }
}