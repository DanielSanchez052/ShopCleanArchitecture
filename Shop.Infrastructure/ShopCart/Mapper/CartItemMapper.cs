using Shop.Application.Interfaces;
using Shop.Entities.ShopCart;
using Shop.Infrastructure.ShopCart.Dtos;

namespace Shop.Infrastructure.ShopCart.Mapper;

public class CartItemMapper : IMapper<CartItemDto, CartItem>
{
    public CartItem ToEntity(CartItemDto dto)
    {
        return new CartItem(dto.ReferenceGuid, string.Empty, 0, dto.Quantity);
    }
}
