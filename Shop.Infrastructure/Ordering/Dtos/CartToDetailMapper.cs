using Shop.Application.Interfaces;
using Shop.Entities.Ordering;
using Shop.Entities.Ordering.Enum;
using Shop.Entities.ShopCart;

namespace Shop.Infrastructure.Ordering.Dtos;

public class CartToDetailMapper : IMapper<CartItem, OrderDetail>
{
    public OrderDetail ToEntity(CartItem dto)
    {
        var detail = OrderDetail.Create((int)OrderDetailStatusEnum.Pending, dto.ReferenceGuid, dto.Quantity, dto.Price);
        return detail;
    }
}
