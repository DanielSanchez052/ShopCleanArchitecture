using Shop.Application.Catalog.Specifications;
using Shop.Application.Interfaces;
using Shop.Entities.Catalog;

namespace Shop.Application.Catalog.UseCases.Read;

public class GetProductByIdUseCase<TOutput>
{
    private readonly IRepository<Product> _productRepository;
    private readonly IPresenter<Product, TOutput> _presenter;

    public GetProductByIdUseCase(IRepository<Product> productRepository, IPresenter<Product, TOutput> presenter)
    {
        _productRepository = productRepository;
        _presenter = presenter;
    }

    public async Task<TOutput?> ExecuteAsync(string productCode)
    {
        var spec = new CatalogProductSpecification(productCode);

        var product = await _productRepository.GetEntityWithSpec(spec);
        return _presenter.Present(product);
    }
}
