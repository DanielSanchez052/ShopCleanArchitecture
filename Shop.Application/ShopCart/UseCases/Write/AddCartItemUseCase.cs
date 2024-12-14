using Microsoft.Extensions.Logging;
using Shop.Application.Catalog.Specifications;
using Shop.Application.Interfaces;
using Shop.Application.Primitives.Result;
using Shop.Application.ShopCart.Specifications;
using Shop.Entities.Catalog;
using Shop.Entities.ShopCart;

namespace Shop.Application.ShopCart.UseCases.Write;

public class AddCartItemUseCase<Dto>
{
    private readonly IRepository<Cart> _repository;
    private readonly IRepository<CartItem> _itemsRepository;
    private readonly IMapper<Dto, CartItem> _mapper;
    private readonly IRepository<ProgramProductReference> _referenceRepository;
    private readonly IDbContext _dbContext;
    private readonly ILogger<AddCartItemUseCase<Dto>> _logger;

    public AddCartItemUseCase(IRepository<Cart> repository, IRepository<CartItem> itemsRepository, IMapper<Dto, CartItem> mapper, IRepository<ProgramProductReference> referenceRepository, IDbContext dbContext, ILogger<AddCartItemUseCase<Dto>> logger)
    {
        _repository = repository;
        _itemsRepository = itemsRepository; 
        _mapper = mapper;
        _referenceRepository = referenceRepository;
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<Result<string>> ExecuteAsync(string cartGuid, Dto dto)
    {
        if (dto is null) throw new ArgumentNullException(nameof(dto));

        try
        {
            var item = _mapper.ToEntity(dto);
            var maybeCart = await _repository.GetEntityWithSpec(new GetCartByIdSpec(cartGuid));

            if (maybeCart.HasNoValue)
            {
                return Result.Failure<string>(Errors.Cart.NotFound);
            }
            var referenceSpecification = new GetActiveReferenceSpecification(item.ReferenceGuid);
            var maybeRefence = await _referenceRepository.GetEntityWithSpec(referenceSpecification);

            if (maybeRefence.HasNoValue)
            {
                return Result.Failure<string>(Errors.Cart.ReferenceNotFound);
            }

            var name = maybeRefence.Value?.Name ?? "";
            var price = maybeRefence.Value?.ProgramProduct?.GetPrice();

            if(price == null || price <= 0)
            {
                _logger.LogError($"Error creating cart, reference {maybeRefence.Value?.Guid} price is null or zero");
                return Result.Failure<string>(Errors.Cart.CouldNotSave);
            }

            var quantity = item.Quantity + maybeCart.Value?.CartItems?.FirstOrDefault(x => x.ReferenceGuid == item.ReferenceGuid)?.Quantity ?? 0;

            if (quantity > maybeRefence.Value?.Available)
            {
                return Result.Failure<string>(Errors.Cart.ReferenceNotInventory);
            }

            item.SetCartItemDetail(maybeCart.Value?.Guid ?? "", name, price.Value);
            maybeCart.Value?.AddItem(item);

            if (maybeCart.Value?.CartItems.Any(x => x.Guid == item.Guid) == true)
            {
                await _itemsRepository.AddAsync(item);
            }
            else
            {
                _repository.Update(maybeCart.Value);
            }
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            { 
                return Result.Success(cartGuid);
            }

            return Result.Failure<string>(Errors.Cart.CouldNotSave);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating cart");
            return Result.Failure<string>(Errors.Cart.CouldNotSave);
        }

    }
}
