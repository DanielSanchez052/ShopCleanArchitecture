using Microsoft.Extensions.Logging;
using Shop.Application.Interfaces;
using Shop.Application.Primitives;
using Shop.Application.Primitives.Result;
using Shop.Entities.Catalog;

namespace Shop.Application.Catalog.UseCases.Write;

public class AddProductReferenceUseCase<TDto>
{
    private readonly IRepository<ProgramProductReference> _repository;
    private readonly IRepository<ProgramProduct> _productRepository;
    private readonly IMapper<TDto, ProgramProductReference> _mapper;
    private readonly IDbContext _context;
    private readonly ILogger<AddProductReferenceUseCase<TDto>> _logger;

    public AddProductReferenceUseCase(IRepository<ProgramProductReference> repository, IMapper<TDto, ProgramProductReference> mapper, IDbContext context
        , ILogger<AddProductReferenceUseCase<TDto>> logger, IRepository<ProgramProduct> productRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _context = context;
        _logger = logger;
        _productRepository = productRepository;
    }

    public async Task<Result<string>> ExecuteAsync(TDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        try
        {
            var errors = new List<Error>();
            var entity = _mapper.ToEntity(dto);

            var product = await _productRepository.GetByString(entity.ProgramProductGuid);

            if (product.HasNoValue)
                errors.Add(Errors.ProgramProduct.NotFound);

            if (errors.Count > 0)
            {
                return Result.Failure<string>(new Error("General", "validation error"), errors.ToArray());
            }

            await _repository.AddAsync(entity);

            int result = await _context.SaveChangesAsync();

            if (result == 0)
                return Result.Failure<string>(Errors.ProductReference.CouldNotSave);

            return Result.Success(entity.Guid);
        }
        catch (Exception ex)
        {
            _logger.LogError(string.Format("{0} : {1}", ex.Message, ex.InnerException?.Message));
            return Result.Failure<string>(Errors.ProductReference.CouldNotSave);
        }
    }
}
