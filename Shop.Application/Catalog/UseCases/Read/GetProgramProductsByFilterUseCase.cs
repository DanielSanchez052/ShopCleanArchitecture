using Microsoft.Extensions.Logging;
using Shop.Application.Catalog.Specifications;
using Shop.Application.Interfaces;
using Shop.Entities.Catalog;

namespace Shop.Application.Catalog.UseCases.Read;

public class GetProgramProductsByFilterUseCase<TOutput>
{
    private readonly IRepository<ProgramProduct> _productRepository;
    private readonly IPresenter<ProgramProduct, TOutput> _presenter;
    private readonly ILogger<GetProgramProductsByFilterUseCase<TOutput>> _logger;

    public GetProgramProductsByFilterUseCase(IRepository<ProgramProduct> productRepository, IPresenter<ProgramProduct, TOutput> presenter
        , ILogger<GetProgramProductsByFilterUseCase<TOutput>> logger)
    {
        _productRepository = productRepository;
        _presenter = presenter;
        _logger = logger;
    }

    public async Task<PagedList<TOutput>> ExecuteAsync(int programId, ProgramProductFilterParams filters)
    {
        if (filters == null)
        {
            filters = new();
        }

        var pagedList = new PagedList<TOutput>(new List<TOutput>(), filters.PageIndex, filters.PageSize, 0);

        try
        {
            var specFilter = new GetProgramProductSpecification(programId, filters);
            var specFilterCount = new GetProgramProductSpecificationCount(programId, filters);

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
