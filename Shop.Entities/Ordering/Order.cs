using Shop.Entities.Customer;
using Shop.Entities.Payment;

namespace Shop.Entities.Ordering;

public class Order
{
    public Order()
    {
        Id = Ulid.NewUlid().ToString();
    }

    public string Id { get; private set; } = null!;
    public int? AddressId { get; private set; }
    public Address? Address { get; private set; }
    public DateTime CreateDate { get; private set; }
    public DateTime? AproveDate { get; private set; }
    public DateTime? UpdateDate { get; private set; }
    public string AccountGuid { get; private set; } = null!;
    public Account Account{ get; private set; } = null!;
    public int PaymentTypeId { get; private set; } 
    public PaymentType PaymentType { get; private set; } = null!;
    public int StatusId { get; private set; }
    public OrderStatus Status { get; private set; }

    private readonly List<OrderDetail> _orderDetails = new List<OrderDetail>();
    public virtual IReadOnlyCollection<OrderDetail> OrderDetails => _orderDetails;

    private readonly List<OrderChangeHistory> _changeHistory = new List<OrderChangeHistory>();
    public virtual IReadOnlyCollection<OrderChangeHistory> ChangeHistory => _changeHistory;
}
