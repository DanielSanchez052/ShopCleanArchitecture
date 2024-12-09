using Shop.Application.Primitives;

namespace Shop.Application.ShopCart;

public static partial class Errors
{
    public static class Cart
    {
        public static Error CouldNotSave = new Error("Cart.CouldNotSave", "Cart could not be saved");
        public static Error AccountNotFound = new Error("Cart.AccountNotFound", "Account not found");

    }
}
