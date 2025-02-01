namespace Shop.Infrastructure.Ordering.Dtos;

public class OrderDto
{
    public int? AddressId { get; set; }
    public string? AccountGuid { get; set; }
    public int PaymentId { get; set; }
    public string? CartId { get; set; }
}
