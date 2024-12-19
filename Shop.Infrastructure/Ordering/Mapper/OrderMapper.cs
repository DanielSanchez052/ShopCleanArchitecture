using Shop.Application.Interfaces;
using Shop.Entities.Ordering;
using Shop.Infrastructure.Ordering.Dtos;

namespace Shop.Infrastructure.Ordering.Mapper;

public class OrderMapper : IMapper<OrderDto, Order>
{
    public Order ToEntity(OrderDto dto)
    {
        return Order.Create(dto.AddressId, dto.AccountGuid, dto.PaymentId);
    }
}
