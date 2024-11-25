using Microsoft.Extensions.Logging;
using Shop.Application.Catalog.Specifications;
using Shop.Application.Interfaces;
using Shop.Application.Primitives.Result;
using Shop.Entities.Catalog;

namespace Shop.Application.Catalog.UseCases.Write;

public class AddProductToProgramUseCase<TDto>
{
    private readonly IRepository<ProgramProduct> _repository;
    private readonly IRepository<Product> _productrepository;
    private readonly IRepository<Entities.Config.Program> _programRepository;
    private readonly IMapper<TDto, ProgramProduct> _mapper;
    private readonly IDbContext _context;
    private readonly ILogger<AddProductToProgramUseCase<TDto>> _logger;

    public AddProductToProgramUseCase(IRepository<ProgramProduct> repository
        , IMapper<TDto
        , ProgramProduct> mapper
        , IRepository<Entities.Config.Program> programRepository
        , IRepository<Product> productrepository
        , IDbContext context
        , ILogger<AddProductToProgramUseCase<TDto>> logger
        )
    {
        _repository = repository;
        _programRepository = programRepository;
        _productrepository = productrepository;
        _mapper = mapper;
        _context = context;
        _logger = logger;
    }

    public async Task<Result<string>> ExecuteAsync(TDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));


        var entity = _mapper.ToEntity(dto);

        try
        {
            var programExists = await _programRepository.GetByInt(entity.ProgramId);

            if (programExists == null)
                return Result.Failure<string>(Program.Errors.Program.NotFound);

            var productExists = await _productrepository.GetByString(entity.ProductGuid);
            if (productExists.HasNoValue)
                return Result.Failure<string>(Errors.Product.NotFound);

            var programSpec = new GetProductByGuidSpecification(entity.ProductGuid, entity.ProgramId);
            var programProductExists = await _repository.CountAsync(programSpec);

            if (programProductExists > 0)
                return Result.Failure<string>(Errors.ProgramProduct.AlreadyExists);


            await _repository.AddAsync(entity);
            int result = await _context.SaveChangesAsync();
            if (result == 0)
                return Result.Failure<string>(Errors.ProgramProduct.CouldNotSave);

            return Result.Success(entity.Guid);

        }
        catch (Exception ex) { 
            _logger.LogError(string.Format("{0} : {1}", ex.Message, ex.InnerException?.Message));
            return Result.Failure<string>(Errors.ProgramProduct.CouldNotSave);
        }
    }
}
