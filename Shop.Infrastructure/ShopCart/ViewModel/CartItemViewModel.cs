 namespace Shop.Infrastructure.ShopCart.ViewModel;

public class CartItemViewModel
{
    public CartItemViewModel(string guid, string referenceGuid, string name, string price, int quantity, decimal totalPrice)
    {
        Guid = guid;
        ReferenceGuid = referenceGuid;
        Name = name;
        Price = price;
        Quantity = quantity;
        TotalPrice = totalPrice;
    }

    public string Guid { get; set; }
    public string ReferenceGuid { get; set; }
    public string Name { get; set; }
    public string Price { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}
