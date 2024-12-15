using Shop.Application.Interfaces;
using Shop.Entities.Ordering;
using Shop.Infrastructure.Ordering.ViewModel;

namespace Shop.Infrastructure.Ordering.Presenter;

public class PaymentTypePresenter : IPresenter<PaymentType, PaymentTypeViewModel>
{
    public PaymentTypeViewModel? Present(PaymentType? entity)
    {
        if (entity == null) return null;

        return new PaymentTypeViewModel()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description
        };
    }

    public IEnumerable<PaymentTypeViewModel?> PresentCollection(IEnumerable<PaymentType> entities)
    {
        return entities.Select(Present);
    }
}
