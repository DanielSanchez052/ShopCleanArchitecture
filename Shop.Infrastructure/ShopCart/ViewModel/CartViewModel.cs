namespace Shop.Infrastructure.ShopCart.ViewModel;

public class CartViewModel
{
    public CartViewModel(string guid, List<CartItemViewModel> items)
    {
        Guid = guid;
        Items = items;
    }

    public string Guid { get; set; } = null!;
    public List<CartItemViewModel> Items { get; set; } = new();
}
