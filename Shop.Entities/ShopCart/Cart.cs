using Shop.Entities.Customer;

namespace Shop.Entities.ShopCart;

public class Cart
{
    public Cart(string accountId)
    {
        Guid = System.Guid.NewGuid().ToString();
        CreateDate = DateTime.Now;
        AccountGuid = accountId;
        IsActive = true;
    }

    public Cart()
    {
    }

    private readonly List<CartItem> _cartItems = new(); // Private field for cart items>

    public string Guid { get; private set; } = null!;
    public DateTime CreateDate { get; private set; }
    public bool IsActive { get; private set; }
    public IReadOnlyCollection<CartItem> CartItems => _cartItems; // Public property for cart items>
    public string AccountGuid { get; private set; } = null!;
    public Account Account { get; private set; }

    public decimal GetTotalPrice() => _cartItems.Sum(x => x.GetTotalPrice());
    public void AddItem(CartItem cartItem)
    {
        if (_cartItems.Any(x => x.ReferenceGuid == cartItem.ReferenceGuid))
        {
            _cartItems.First(x => x.ReferenceGuid == cartItem.ReferenceGuid).AddQuantity(cartItem.Quantity);
        }
        else
        {
            _cartItems.Add(cartItem);
        }
    }
    public void RemoveItem(string itemId)
    {
        var item = _cartItems.FirstOrDefault(x => x.Guid == itemId);
        if (item == null) return;
        _cartItems.Remove(item);
    }
    public void RemoveAllItems()
    {
        _cartItems.Clear();
    }
}
