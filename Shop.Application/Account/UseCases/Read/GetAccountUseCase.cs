using Shop.Application.Interfaces;
using Shop.Application.Primitives.Maybe;
using Shop.Application.Primitives.Result;

namespace Shop.Application.Account.UseCases.Read;

public class GetAccountUseCase<TOutput>
{
    private readonly IRepository<Entities.Customer.Account> _repository;
    private readonly IPresenter<Entities.Customer.Account, TOutput> _presenter;

    public GetAccountUseCase(IRepository<Entities.Customer.Account> repository, IPresenter<Entities.Customer.Account, TOutput> presenter)
    {
        _repository = repository;
        _presenter = presenter;
    }

    public async Task<Maybe<TOutput>> ExecuteAsync(string accountId)
    {
        if (string.IsNullOrEmpty(accountId)) 
            throw new ArgumentNullException(nameof(accountId));

        var account = await _repository.GetByString(accountId);

        if(account == null || account.HasNoValue)
        {
            return Maybe<TOutput>.None;
        }

        var presented = _presenter.Present(account.Value);
        return Maybe<TOutput>.From(presented);
        
    }
}
