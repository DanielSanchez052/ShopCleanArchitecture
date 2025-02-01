using Microsoft.Extensions.Logging;
using Shop.Application.Interfaces;
using Shop.Application.Ordering.Specifications;
using Shop.Entities.Ordering;

namespace Shop.Application.Ordering.UseCases.Read;

public class GetOrderHistoryUseCase<TOutput>
{
    private readonly IRepository<Order> _repository;
    private readonly IPresenter<Order, TOutput> _presenter;
    private readonly ILogger<GetOrderHistoryUseCase<TOutput>> _logger;

    public GetOrderHistoryUseCase(IRepository<Order> repository, IPresenter<Order, TOutput> presenter, ILogger<GetOrderHistoryUseCase<TOutput>> logger)
    {
        _repository = repository;
        _logger = logger;
        _presenter = presenter;
    }


    public async Task<PagedList<TOutput>> ExecuteAsync(OrderHistoryFilterParams filters, string accountId, int programId)
    {
        if (filters == null)
            filters = new();

        var pagedList = new PagedList<TOutput>(new List<TOutput>(), filters.PageSize, filters.PageSize, 0);

        try
        {
            var specFilter = new GetOrderCompleteByFilterSpecification(filters, accountId, programId);
            var specFilterCount = new GetOrderCompleteCountByFilterSpecification(filters, accountId, programId);

            var orderHistory = await _repository.ListAsync(specFilter);
            var orderHistoryCount = await _repository.CountAsync(specFilterCount);

            pagedList = new PagedList<TOutput>(_presenter.PresentCollection(orderHistory), filters.PageSize, filters.PageSize, orderHistoryCount);
        }
        catch (Exception ex)
        {
            _logger.LogError("{0}: {1}", ex.Message, ex.StackTrace);

        }
        return pagedList;
    }
}
