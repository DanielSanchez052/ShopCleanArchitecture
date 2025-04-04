﻿using Microsoft.EntityFrameworkCore;
using Shop.Application.Specifications;
using Shop.Entities.ShopCart;


namespace Shop.Application.ShopCart.Specifications;

public class GetCartByIdSpec : BaseSpecification<Cart>
{
    public GetCartByIdSpec(string guid, int programId) 
        : base(x => x.Guid == guid && x.Account.ProgramId == programId && x.IsActive)
    {
        AddInclude(x => x.CartItems);
    }
}

public class GetCartsActiveSpec : BaseSpecification<Cart>
{
    public GetCartsActiveSpec(string accountGuid, int programId) 
        : base(x => x.AccountGuid == accountGuid 
            && x.Account.ProgramId == programId && x.IsActive
        )
    {
        //AddInclude(x => x.CartItems);
        AddNestedInclude(q => 
            q.Include(x => x.CartItems)
                .ThenInclude(x => x.Reference)
                .ThenInclude(x => x.ProgramProduct)
                .ThenInclude(x => x.Product)
        );
        // TODO: add expiration date
        AddNestedInclude(q =>
            q.Include(x => x.CartItems)
                .ThenInclude(x => x.Reference)
                .ThenInclude(x => x.Codes.Where(x => x.IsActive && x.Used == false))
        );


        ApplySplitQuery();
    }
}


public class GetCartsExpiredSpec : BaseSpecification<Cart>
{
    public GetCartsExpiredSpec(string accountGuid, int programId ,int expirationDays) 
        : base(x => x.CreateDate.AddDays(expirationDays) < DateTime.Now && x.AccountGuid == accountGuid && x.Account.ProgramId == programId )
    {
    }
}

public class GetCartsByAccountSpec : BaseSpecification<Cart>
{
    public GetCartsByAccountSpec(string accountGuid)
        : base(x => x.AccountGuid == accountGuid && x.IsActive)
    {
    }
}