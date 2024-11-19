using Microsoft.Extensions.Logging;
using Shop.Application.Catalog.Specifications;
using Shop.Application.Interfaces;
using Shop.Entities.Catalog;

namespace Shop.Application.Catalog.UseCases;

public class GetProductsByFilterUseCase<TOutput>
{
    private readonly IRepository<Product> _productRepository;
    private readonly IPresenter<Product, TOutput> _presenter;
    private readonly ILogger<GetProductsByFilterUseCase<TOutput>> _logger;

    public GetProductsByFilterUseCase(IRepository<Product> productRepository, IPresenter<Product, TOutput> presenter
        , ILogger<GetProductsByFilterUseCase<TOutput>> logger)
    {
        _productRepository = productRepository;
        _presenter = presenter;
        _logger = logger;
    }

    public async Task<PagedList<TOutput>> ExecuteAsync(ProductFilterParams? filters)
    {
        if (filters == null)
        {
            filters = new();
        }
        var pagedList = new PagedList<TOutput>(new List<TOutput>(), filters.PageIndex, filters.PageSize, 0);
        try
        {
            var specFilter = new GetProductsByFilterSpecification(filters);
            var specFilterCount = new GetProductsByFilterCountSpecification(filters);


            var products = await _productRepository.ListAsync(specFilter);
            var productsCount = await _productRepository.CountAsync(specFilterCount);


            pagedList = new PagedList<TOutput>(_presenter.PresentCollection(products), filters.PageIndex, filters.PageSize, productsCount);
        }
        catch (Exception ex)
        {
            _logger.LogError("{0}: {1}", ex.Message, ex.StackTrace);
        }


        return pagedList;
    }
}
