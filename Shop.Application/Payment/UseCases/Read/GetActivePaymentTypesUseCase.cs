using Shop.Application.Interfaces;
using Shop.Application.Payment.Specifications;
using Shop.Entities.Payment;

namespace Shop.Application.Payment.UseCases.Read;

public class GetActivePaymentTypesUseCase<TOutput>
{
    private readonly IRepository<PaymentType> _repository;
    private readonly IPresenter<PaymentType, TOutput> _presenter;

    public GetActivePaymentTypesUseCase(IRepository<PaymentType> repository, IPresenter<PaymentType, TOutput> presenter)
    {
        _repository = repository;
        _presenter = presenter;
    }

    public async Task<IEnumerable<TOutput>> ExecuteAsync()
    {
        var spec = new GetActivePaymentTypesSpecification();
        var paymentTypes = await _repository.ListAsync(spec);
        return _presenter.PresentCollection(paymentTypes);
    }

}
