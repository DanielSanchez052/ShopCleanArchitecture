using Shop.Application.Primitives;

namespace Shop.Application.Ordering;

public partial class Errors
{
    public static class Order
    {
        public static Error CouldNotSave => new Error("Order.CouldNotSave", "Could not save order.");
        public static Error CartNotFound => new Error("Order.CartNotFound", "Cart not found.");
        public static Error CartIsEmpty => new Error("Order.CartIsEmpty", "cart is empty.");
    }
}
 