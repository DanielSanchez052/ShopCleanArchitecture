using Shop.Entities.Config;
using Shop.Entities.Customer;
using Shop.Entities.Ordering.Enum;
using Shop.Entities.Payment;

namespace Shop.Entities.Ordering;

public class Order
{
    public Order()
    {
        Id = Ulid.NewUlid().ToString();
    }
    protected Order(int? addressId, string accountGuid, int paymentTypeId, int statusId)
    {
        Id = Ulid.NewUlid().ToString();
        AddressId = addressId;
        CreateDate = DateTime.Now;
        AproveDate = null;
        UpdateDate = null;
        AccountGuid = accountGuid;
        PaymentTypeId = paymentTypeId;
        StatusId = statusId;
    }

    public string Id { get; private set; } = null!;
    public int? AddressId { get; private set; }
    public Address? Address { get; private set; }
    public DateTime CreateDate { get; private set; }
    public DateTime? AproveDate { get; private set; }
    public DateTime? UpdateDate { get; private set; }
    public string AccountGuid { get; private set; } = null!;
    public Account Account { get; private set; } = null!;
    public int PaymentTypeId { get; private set; }
    public PaymentType PaymentType { get; private set; } = null!;
    public int StatusId { get; private set; }
    public OrderStatus Status { get; private set; }
    public int ProgramId { get; private set; }
    public Program Program { get; private set; }

    private readonly List<OrderDetail> _orderDetails = new List<OrderDetail>();
    public virtual IReadOnlyCollection<OrderDetail> OrderDetails => _orderDetails;

    private readonly List<OrderChangeHistory> _changeHistory = new List<OrderChangeHistory>();
    public virtual IReadOnlyCollection<OrderChangeHistory> ChangeHistory => _changeHistory;

    public static Order Create(int addressId, string accountGuid, int paymentTypeId)
    {
        var order = new Order(addressId, accountGuid, paymentTypeId, (int)OrderStatusEnum.Pending);

        return order;
    }

    public void AssignToProgram(int programId)
    {
        ProgramId = programId;
    }

    public decimal GetTotal()
    {
        return _orderDetails.Sum(x => (x.Quantity * x.UnitPrice)-x.Discount);
    } 
    public void AddDetails(List<OrderDetail> details)
    {
        foreach(var detail in details)
        {
            detail.SetOrderId(Id);
            _orderDetails.Add(detail);
        }
    }

    public void Approve()
    {
        StatusId = (int)OrderStatusEnum.Approved;
        AproveDate = DateTime.Now;
    }

    public void Cancel()
    {
        StatusId = (int)OrderStatusEnum.Canceled;
    }

    public bool CanApprove()
    {
        return StatusId == (int)OrderStatusEnum.Pending && AproveDate == null;
    }

    public bool CanCancel()
    {
        return StatusId == (int)OrderStatusEnum.Pending && AproveDate == null;
    }
}
