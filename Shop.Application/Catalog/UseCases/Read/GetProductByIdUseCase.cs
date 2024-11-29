using Shop.Application.Catalog.Specifications;
using Shop.Application.Interfaces;
using Shop.Application.Primitives.Maybe;
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

    public async Task<Maybe<TOutput>> ExecuteAsync(string productCode)
    {
        var spec = new CatalogProductSpecification(productCode);

        var product = await _productRepository.GetEntityWithSpec(spec);

        if (product.HasNoValue)
        {
            return Maybe<TOutput>.None;
        }

        return Maybe<TOutput>.From(_presenter.Present(product));
    }
}
