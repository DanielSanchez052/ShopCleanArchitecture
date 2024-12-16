namespace Shop.Infrastructure.Payment.ViewModel;

public class PaymentTypeViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}
