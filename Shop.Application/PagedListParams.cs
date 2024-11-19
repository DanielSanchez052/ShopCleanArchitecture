namespace Shop.Application;

public class PagedListParams
{
    //Paginado
    private const int MaxPageSize = 100;

    private int _pageSize = 10;
    public int PageIndex { get; set; } = 1;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
}
