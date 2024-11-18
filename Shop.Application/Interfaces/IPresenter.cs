namespace Shop.Application.Interfaces;

public interface IPresenter<TEntity, TOutput>
{
    IEnumerable<TOutput> PresentCollection(IEnumerable<TEntity> entities);
    TOutput? Present(TEntity? entity);
}
