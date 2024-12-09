using Shop.Application.Interfaces;
using Shop.Entities.ShopCart;
using Shop.Infrastructure.ShopCart.ViewModel;

namespace Shop.Infrastructure.ShopCart.Presenter;

public class CartPresenter : IPresenter<Cart, CartViewModel>
{
    public CartViewModel? Present(Cart? entity)
    {
        if(entity == null) return null;

        return new CartViewModel(entity.Guid, entity.CartItems.Select(PresentItem).ToList());
    }

    public CartItemViewModel PresentItem(CartItem item)
    {
        return new CartItemViewModel(item.Guid, item.ReferenceGuid ?? "", item.Name, $"${item.Price}", item.Quantity, item.GetTotalPrice());
    }

    public IEnumerable<CartViewModel?> PresentCollection(IEnumerable<Cart> entities)
    {
        return entities.Select(Present);
    }
}
