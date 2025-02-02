using Shop.Infrastructure.Catalog.ViewModel;

namespace Shop.Infrastructure.Ordering.ViewModel;

public class OrderDetailViewModel
{
    public string Guid { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public int StatusId { get; set; }
    public string StatusName { get; set; }
    public ProgramProductViewModel? Product { get; set; }
}
