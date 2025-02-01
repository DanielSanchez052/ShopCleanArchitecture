namespace Shop.Application.Ordering;

public class OrderHistoryFilterParams : PagedListParams
{
    public int? StatusId { get; set; }
    public string AccountId { get; set; }
}
