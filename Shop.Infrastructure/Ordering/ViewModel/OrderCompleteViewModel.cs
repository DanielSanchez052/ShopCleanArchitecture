using Shop.Infrastructure.Payment.ViewModel;

namespace Shop.Infrastructure.Ordering.ViewModel;

public class OrderCompleteViewModel
{
    public string OrderId { get; set; }
    public int StatusId { get; set; }
    public string StatusName { get; set; }
    public DateTime? ApproveDate { get; set; }
    public decimal Total { get; set; }
    public PaymentTypeViewModel? PaymentType { get; set; }
    public List<OrderDetailViewModel> Details { get; set; }
}

