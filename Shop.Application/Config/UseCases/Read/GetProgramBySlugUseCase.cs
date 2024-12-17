using Microsoft.Extensions.Caching.Memory;
using Shop.Application.Config.Specifications;
using Shop.Application.Interfaces;
using ProgramEntity = Shop.Entities.Config.Program;

namespace Shop.Application.Config.UseCases.Read;

public class GetProgramBySlugUseCase<Dto>
{
    private readonly IRepository<ProgramEntity> _repository;
    private readonly IPresenter<ProgramEntity, Dto> _presenter;
    private readonly IMemoryCache _cache;

    public GetProgramBySlugUseCase(IRepository<ProgramEntity> repository, IPresenter<ProgramEntity, Dto> presenter, IMemoryCache cache)
    {
        _repository = repository;
        _presenter = presenter;
        _cache = cache;
    }

    public async Task<Dto?> ExecuteAsync(string slug)
    {
        var cacheKey = $"cache_program_{slug}";
        Dto? program = _cache.Get<Dto>(cacheKey);

        if(program is null)
        {
            var spec = new GetProgramBySlugSpecification(slug);
            var programDb = await _repository.GetEntityWithSpec(spec);
            if(programDb.HasNoValue)
            {
                return default(Dto);
            }

            program = _presenter.Present(programDb);

        }

        return program;
    }

}
