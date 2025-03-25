using Microsoft.Extensions.Logging;
using Shop.Application.Interfaces;
using Shop.Application.Primitives;
using Shop.Application.Primitives.Result;
using Shop.Application.ShopCart.Specifications;
using Shop.Entities.Ordering;
using Shop.Entities.ShopCart;
using CartErrors = Shop.Application.ShopCart.Errors;
using CatalogErrors = Shop.Application.Catalog.Errors;

namespace Shop.Application.Ordering.UseCases.Write;

public class CreateOrderUseCase<TDto>
{
    private readonly IRepository<Order> _repository;
    private readonly IRepository<Cart> _cartRepository;
    private readonly IMapper<TDto, Order> _mapper;
    private readonly IMapper<CartItem, OrderDetail> _mapperDetail;
    private readonly IDbContext _context;
    private readonly ILogger<CreateOrderUseCase<TDto>> _logger;

    public CreateOrderUseCase(IRepository<Order> repository, IRepository<Cart> cartRepository, IMapper<TDto, Order> mapper, IMapper<CartItem, OrderDetail> mapperDetail, IDbContext context, ILogger<CreateOrderUseCase<TDto>> logger)
    {
        _repository = repository;
        _cartRepository = cartRepository;
        _mapper = mapper;
        _mapperDetail = mapperDetail;
        _context = context;
        _logger = logger;
    }

    public async Task<Result<string>> ExecuteAsync(TDto dto, int programId)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        try
        {
            var errors = new List<Error>();
            var entity = _mapper.ToEntity(dto);
            entity.AssignToProgram(programId);

            var cart = await GetActiveCartAsync(entity.AccountGuid, programId, errors);
            if (cart == null)
                return Result.Failure<string>(new Error("General", "validation error"), errors.ToArray());

            var invalidItems = cart.GetCartItemsWithInventoryInvalid();
            if (invalidItems != null && invalidItems.Count > 0)
            {
                errors.AddRange(invalidItems.Select(x => CatalogErrors.ProductReference.NonInventoryReference(x.Reference.Name)));
                return Result.Failure<string>(new Error("General", "validation error"), errors.ToArray());
            }

            var details = cart.CartItems.Select(x => _mapperDetail.ToEntity(x)).ToList();
            entity.AddDetails(details);

            await _repository.AddAsync(entity);
            _cartRepository.Delete(cart);

            var rowsSaved = await _context.SaveChangesAsync();
            if (rowsSaved == 0)
                return Result.Failure<string>(Errors.Order.CouldNotSave);

            return Result.Success<string>(entity.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating order");
            return Result.Failure<string>(Errors.Order.CouldNotSave);
        }
    }

    private async Task<Cart?> GetActiveCartAsync(string accountGuid, int programId, List<Error> errors)
    {
        var specification = new GetCartsActiveSpec(accountGuid, programId);
        var cartMaybe = await _cartRepository.GetEntityWithSpec(specification);

        if (cartMaybe.HasNoValue)
        {
            errors.Add(Errors.Order.CartNotFound);
            return null;
        }

        var cart = cartMaybe.Value;
        if (cart.CartItems.Count == 0)
        {
            errors.Add(Errors.Order.CartIsEmpty);
            return null;
        }

        return cart;
    }
}