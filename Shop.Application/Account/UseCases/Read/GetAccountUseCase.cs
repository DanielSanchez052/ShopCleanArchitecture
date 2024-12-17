using Shop.Application.Account.Specifications;
using Shop.Application.Interfaces;
using Shop.Application.Primitives.Maybe;

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

    public async Task<Maybe<TOutput>> ExecuteAsync(string accountId, int programId)
    {
        if (string.IsNullOrEmpty(accountId))
            throw new ArgumentNullException(nameof(accountId));

        var spec = new GetAccountByIdSpecification(accountId, programId);
        var account = await _repository.GetEntityWithSpec(spec);

        if (account == null || account.HasNoValue)
        {
            return Maybe<TOutput>.None;
        }

        var presented = _presenter.Present(account.Value);
        return Maybe<TOutput>.From(presented);

    }
}
