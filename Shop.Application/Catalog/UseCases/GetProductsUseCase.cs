using Shop.Application.Interfaces;

namespace Shop.Application.Catalog.UseCases;

public class GetProductsUseCase<T, TOutput>
{
    private readonly IRepository<T> _productRepository;
    private readonly IPresenter<T, TOutput> _presenter;

    public GetProductsUseCase(IRepository<T> productRepository, IPresenter<T, TOutput> presenter)
    {
        _productRepository = productRepository;
        _presenter = presenter;
    }

    public async Task<IEnumerable<TOutput>> ExecuteAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return _presenter.PresentCollection(products);
    }
}
