using Microsoft.Extensions.Logging;
using Shop.Application.Interfaces;
using Shop.Application.Primitives;
using Shop.Application.Primitives.Result;
using Shop.Entities.Catalog;

namespace Shop.Application.Catalog.UseCases.Write;

public class AddProductUseCase<TDto>
{
    private readonly IRepository<Product> _repository;
    private readonly IRepository<ProductType> _productTypeRepository;
    private readonly IRepository<Category> _categoryRepository;
    private readonly IMapper<TDto, Product> _mapper;
    private readonly IDbContext _context;
    private readonly ILogger<AddProductUseCase<TDto>> _logger;

    public AddProductUseCase(IRepository<Product> repository, IRepository<ProductType> productTypeRepository, IRepository<Category> categoryRepository, IMapper<TDto, Product> mapper, IDbContext context, ILogger<AddProductUseCase<TDto>> logger)
    {
        _repository = repository;
        _productTypeRepository = productTypeRepository;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _context = context;
        _logger = logger;
    }

    public async Task<Result<string>> ExecuteAsync(TDto dto) 
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        try
        {
            var errors = new List<Error>();

            var entity = _mapper.ToEntity(dto);

            var productType = await _productTypeRepository.GetByInt(entity.ProductTypeId);

            if (productType.HasNoValue)
            {
                errors.Add(Errors.ProductType.NotFound);
            }

            var category = await _categoryRepository.GetByInt(entity.CategoryId);

            if (category.HasNoValue)
            {
                errors.Add(Errors.ProductType.NotFound);
            }

            if(errors.Count > 0)
            {
                return Result.Failure<string>(new Error("General", "validation error"), errors.ToArray());
            }

            await _repository.AddAsync(entity);
            int result = await _context.SaveChangesAsync();
            if (result == 0)
                return Result.Failure<string>(Errors.ProgramProduct.CouldNotSave);

            return Result.Success(entity.Guid);
        }catch (Exception ex)
        {
            _logger.LogError(string.Format("{0} : {1}", ex.Message, ex.InnerException?.Message));
            return Result.Failure<string>(Errors.Product.CouldNotSave);
        }

    }
}
