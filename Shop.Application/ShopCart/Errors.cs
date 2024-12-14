using Shop.Application.Primitives;

namespace Shop.Application.ShopCart;

public static partial class Errors
{
    public static class Cart
    {
        public static Error CouldNotSave = new Error("Cart.CouldNotSave", "Cart could not be saved");
        public static Error AccountNotFound = new Error("Cart.AccountNotFound", "Account not found");
        public static Error ReferenceNotFound = new Error("Cart.ReferenceNotFound", "product reference not found");
        public static Error NotFound = new Error("Cart.NotFound", "cart not found");
        public static Error ReferenceNotInventory = new Error("Cart.ReferenceNotInventory", "product reference not inventory");
        public static Error QuantityInvalid = new Error("Cart.QuantityInvalid", "the quantity is invalid");
    }
}
