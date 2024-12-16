using Shop.Application.Interfaces;
using Shop.Entities.Payment;
using Shop.Infrastructure.Payment.ViewModel;

namespace Shop.Infrastructure.Payment.Presenter;

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
