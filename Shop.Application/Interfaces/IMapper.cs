namespace Shop.Application.Interfaces;

public interface IMapper<TDto, TOutPut> where TOutPut : class
{
    TOutPut ToEntity(TDto dto);
}
