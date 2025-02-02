using Shop.Application.Interfaces;
using Shop.Entities.Catalog;
using Shop.Entities.Ordering;
using Shop.Infrastructure.Catalog.ViewModel;
using Shop.Infrastructure.Ordering.ViewModel;

namespace Shop.Infrastructure.Ordering.Presenter;

public class OrderDetailPresenter : IPresenter<OrderDetail, OrderDetailViewModel>
{
    private readonly IPresenter<ProgramProduct, ProgramProductViewModel> _programProductPresenter;
public OrderDetailPresenter(IPresenter<ProgramProduct, ProgramProductViewModel> programProductPresenter)
    {
        _programProductPresenter = programProductPresenter;
    }

    public OrderDetailViewModel? Present(OrderDetail? entity)
    {
        if (entity == null) return null;

        return new OrderDetailViewModel()
        {
            Guid = entity.Guid,
            UnitPrice = entity.UnitPrice,
            Discount = entity.Discount,
            Quantity = entity.Quantity,
            StatusId = entity.OrderDetailStatusId,
            StatusName = entity.OrderDetailStatus?.Name ?? "",
            Product = entity.ProgramProductReference?.ProgramProduct != null ? _programProductPresenter.Present(entity.ProgramProductReference.ProgramProduct) : null
        };
    }

    public IEnumerable<OrderDetailViewModel?> PresentCollection(IEnumerable<OrderDetail> entities)
    {
        return entities.Select(Present);
    }
}
