using Shop.Application.Interfaces;
using Shop.Application.Primitives.Maybe;
using Shop.Application.ShopCart.Specifications;
using Shop.Entities.ShopCart;

namespace Shop.Application.ShopCart.UseCases.Read;

public class GetCartByGuidUseCase<TOutput>
{
    private readonly IPresenter<Cart, TOutput> _presenter;
    private readonly IRepository<Cart> _repository;

    public GetCartByGuidUseCase(IPresenter<Cart, TOutput> presenter, IRepository<Cart> repository)
    {
        _presenter = presenter;
        _repository = repository;
    }

    public async Task<Maybe<TOutput>> ExecuteAsync(string guid, int programId)
    {
        if (string.IsNullOrEmpty(guid))
            throw new ArgumentNullException(nameof(guid));

        var spec = new GetCartByIdSpec(guid, programId);
        var cart = await _repository.GetEntityWithSpec(spec);

        if (cart.HasNoValue)
        {
            return Maybe<TOutput>.None;
        }

        return Maybe<TOutput>.From(_presenter.Present(cart.Value));
    }
}
