using Shop.Application.Interfaces;
using Shop.Entities.Ordering;
using Shop.Entities.Payment;
using Shop.Infrastructure.Ordering.ViewModel;
using Shop.Infrastructure.Payment.ViewModel;

namespace Shop.Infrastructure.Ordering.Presenter;

public class OrderCompletePresenter : IPresenter<Order, OrderCompleteViewModel>
{
    private readonly IPresenter<PaymentType, PaymentTypeViewModel> _paymentTypePresenter;
    private readonly IPresenter<OrderDetail, OrderDetailViewModel> _orderDetailPresenter;

    public OrderCompletePresenter(IPresenter<PaymentType, PaymentTypeViewModel> paymentTypePresenter, IPresenter<OrderDetail, OrderDetailViewModel> orderDetailPresenter)
    {
        _paymentTypePresenter = paymentTypePresenter;
        _orderDetailPresenter = orderDetailPresenter;
    }

    public OrderCompleteViewModel? Present(Order? entity)
    {
        if (entity == null) return null;
        return new OrderCompleteViewModel()
        {
            OrderId = entity.Id,
            StatusId = entity.StatusId,
            StatusName = entity.Status?.Name ?? "",
            ApproveDate = entity.AproveDate,
            Total = entity.GetTotal(),
            PaymentType = entity.PaymentType != null 
            ? _paymentTypePresenter.Present(entity.PaymentType) 
            : null,
            Details = _orderDetailPresenter.PresentCollection(entity.OrderDetails).ToList()
        };
    }

    public IEnumerable<OrderCompleteViewModel?> PresentCollection(IEnumerable<Order> entities)
    {
        return entities.Select(Present);
    }
}
