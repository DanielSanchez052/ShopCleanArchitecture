using Shop.Application.Interfaces;

namespace Shop.Application.Catalog.UseCases;

public class GetProductByIdUseCase<T, TOutput>
{
    private readonly IRepository<T> _productRepository;
    private readonly IPresenter<T, TOutput> _presenter;

    public GetProductByIdUseCase(IRepository<T> productRepository, IPresenter<T, TOutput> presenter)
    {
        _productRepository = productRepository;
        _presenter = presenter;
    }

    public async Task<TOutput?> ExecuteAsync(string id)
    {
        var product = await _productRepository.GetByString(id);
        return _presenter.Present(product);
    }
}
