using Microsoft.Extensions.Logging;
using Shop.Application.Interfaces;
using Shop.Application.Primitives;
using Shop.Application.Primitives.Result;
using Shop.Application.ShopCart.Specifications;
using Shop.Entities.Ordering;
using Shop.Entities.ShopCart;

namespace Shop.Application.Ordering.UseCases.Write;

public class CreateOrderUseCase<TDto> 
{
    private readonly IRepository<Order> _repository;
    private readonly IRepository<Cart> _cartRepository; // <Cart>
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
        if(dto == null)
            throw new ArgumentNullException(nameof(dto));

        try
        {
            var errors = new List<Error>();
            var entity = _mapper.ToEntity(dto);

            var specification  = new GetCartsActiveSpec(entity.AccountGuid, programId);
            var cartMaybe = await _cartRepository.GetEntityWithSpec(specification);

            if (cartMaybe.HasNoValue)
                errors.Add(Errors.Order.CartNotFound);
            
            if(cartMaybe.HasValue && cartMaybe.Value?.CartItems.Count == 0)
                errors.Add(Errors.Order.CartIsEmpty);

            if(errors.Count > 0)
                return Result.Failure<string>(new Error("General", "validation error"), errors.ToArray());

            var cart = cartMaybe.Value;
            
            var details = cart?.CartItems.Select(x => _mapperDetail.ToEntity(x)).ToList();
             
            entity.AddDetails(details);

            await _repository.AddAsync(entity);

            _cartRepository.Delete(cart);

            var rowsSaved = await _context.SaveChangesAsync();
            
            if (rowsSaved == 0) 
                return Result.Failure<string>(Errors.Order.CouldNotSave);

            return Result.Success<string>(entity.Id);

        }catch(Exception ex) {
            _logger.LogError(string.Format("{0} : {1}", ex.Message, ex.InnerException?.Message));
            return Result.Failure<string>(Errors.Order.CouldNotSave);
        }
      
    }
}
