using Shop.Entities.Catalog;

namespace Shop.Entities.ShopCart;

public class CartItem
{
    public CartItem()
    {
        Guid = System.Guid.NewGuid().ToString();
    }

    public CartItem(string referenceGuid, string name, decimal price, int quantity)
    {
        Guid = System.Guid.NewGuid().ToString();
        ReferenceGuid = referenceGuid;
        Name = name;
        Price = price;
        Quantity = quantity;
    }


    public string Guid { get; private set; } = null!;
    public string? CartGuid { get; private set; }
    public Cart? Cart { get; private set; }
    public string? ReferenceGuid { get; private set; }
    public ProgramProductReference? Reference { get; private set; }
    public string Name { get; private set; } = null!;
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    public decimal GetTotalPrice() => Price * Quantity;

    public void AddQuantity(int quantity) => Quantity += quantity;

    public void SetCartItemDetail(string cartGuid, string name, decimal price)
    {
        CartGuid = cartGuid;
        Name = name;
        Price = price;
    }
}
