using Shop.Application.Interfaces;
using Shop.Application.ShopCart.Specifications;
using Shop.Entities.ShopCart;

namespace Shop.Application.ShopCart.UseCases.Read;

public class GetActiveCartsUseCase<TOutput>
{
    private readonly IPresenter<Cart, TOutput> _presenter;
    private readonly IRepository<Cart> _repository;

    public GetActiveCartsUseCase(IPresenter<Cart, TOutput> presenter, IRepository<Cart> repository)
    {
        _presenter = presenter;
        _repository = repository;
    }

    public async Task<IEnumerable<TOutput>> ExecuteAsync(string accountId, int programId)
    {
        if (string.IsNullOrEmpty(accountId))
            throw new ArgumentNullException(nameof(accountId));

        var spec = new GetCartsActiveSpec(accountId, programId);
        var carts = await _repository.ListAsync(spec);

        return carts.Count() == 0 ? Enumerable.Empty<TOutput>() : _presenter.PresentCollection(carts);
    }
}
