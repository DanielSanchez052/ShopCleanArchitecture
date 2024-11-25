using Shop.Application.Catalog.Specifications;
using Shop.Application.Interfaces;
using Shop.Entities.Catalog;

namespace Shop.Application.Catalog.UseCases.Read;

public class GetCategories<TOutput>
{
    private readonly IRepository<Category> _repository;
    private readonly IPresenter<Category, TOutput> _presenter;

    public GetCategories(IRepository<Category> repository, IPresenter<Category, TOutput> presenter)
    {
        _repository = repository;
        _presenter = presenter;
    }

    public async Task<IEnumerable<TOutput>> ExecuteAsync(int programId)
    {
        var spec = new GetCategoriesSpecification(programId);
        var products = await _repository.ListAsync(spec);
        return _presenter.PresentCollection(products);
    }
}
