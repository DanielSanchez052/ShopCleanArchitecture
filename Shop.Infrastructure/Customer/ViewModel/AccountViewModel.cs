namespace Shop.Infrastructure.Customer.ViewModel;

public class AccountViewModel
{
    public string Guid { get; set; } = null!;
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public bool IsActive { get; set; }
    public IEnumerable<AddressViewModel> Addresses { get; set; }
}
