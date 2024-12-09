using Shop.Application.Interfaces;
using Shop.Entities.ShopCart;
using Shop.Infrastructure.ShopCart.Dtos;

namespace Shop.Infrastructure.ShopCart.Mapper;

public class CartMapper : IMapper<CartDto, Cart>
{
    public Cart ToEntity(CartDto dto)
    {
        var cart = new Cart(dto.AccountGuid);

        return cart;
    }
}
