using Shop.Application.Specifications;
using Shop.Entities.ShopCart;

namespace Shop.Application.ShopCart.Specifications;

public class GetCartByIdSpec : BaseSpecification<Cart>
{
    public GetCartByIdSpec(string guid) : base(x => x.Guid == guid && x.IsActive)
    {

    }
}

public class GetCartsActiveSpec : BaseSpecification<Cart>
{
    public GetCartsActiveSpec() : base(x => x.IsActive)
    {
    }
}


public class GetCartsExpiredSpec : BaseSpecification<Cart>
{
    public GetCartsExpiredSpec(string accountGuid ,int expirationDays) : base(x => x.CreateDate.AddDays(expirationDays) < DateTime.Now && x.AccountGuid == accountGuid)
    {
    }
}