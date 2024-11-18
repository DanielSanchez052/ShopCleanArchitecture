using Shop.Entities.Accounts;

namespace Shop.Entities.Ordering;

public class Order
{
    public string Id { get; set; } = null!;
    public int? AddressId { get; set; }
    public Address? Address { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? AproveDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string AccountGuid { get; set; } = null!;
    public Account Account{ get; set; } = null!;
    public int PaymentTypeId { get; set; } 
    public PaymentType PaymentType { get; set; } = null!;
    public int StatusId { get; set; }
    public OrderStatus Status { get; set; }

    private readonly List<OrderDetail> _orderDetails = new List<OrderDetail>();
    public virtual IReadOnlyCollection<OrderDetail> OrderDetails => _orderDetails;

}
