using Shop.Application.Catalog.Specifications;
using Shop.Application.Interfaces;
using Shop.Entities.Catalog;

namespace Shop.Application.Catalog.UseCases.Read;

public class GetProductTypesUseCase<TOutput>
{
    private readonly IRepository<ProductType> _repository;
    private readonly IPresenter<ProductType, TOutput> _presenter;

    public GetProductTypesUseCase(IRepository<ProductType> repository, IPresenter<ProductType, TOutput> presenter)
    {
        _repository = repository;
        _presenter = presenter;
    }

    public async Task<IEnumerable<TOutput>> ExecuteAsync()
    {
        var spec = new GetProductTypesSpecification();
        var productTypes = await _repository.ListAsync(spec);
        return _presenter.PresentCollection(productTypes);
    }
}
