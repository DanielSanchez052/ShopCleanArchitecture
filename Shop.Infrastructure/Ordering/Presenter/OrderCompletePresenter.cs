using Shop.Application.Interfaces;
using Shop.Entities.Ordering;
using Shop.Infrastructure.Ordering.ViewModel;

namespace Shop.Infrastructure.Ordering.Presenter;

public class OrderCompletePresenter : IPresenter<Order, OrderCompleteViewModel>
{
    public OrderCompleteViewModel? Present(Order? entity)
    {
        if (entity == null) return null;
        return new OrderCompleteViewModel()
        {
            OrderId = entity.Id,
            StatusId = entity.StatusId,
            StatusName = entity.Status?.Name ?? ""
        };
    }

    public IEnumerable<OrderCompleteViewModel?> PresentCollection(IEnumerable<Order> entities)
    {
        return entities.Select(Present);
    }
}
