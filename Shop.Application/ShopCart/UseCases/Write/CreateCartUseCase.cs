using Microsoft.Extensions.Logging;
using Shop.Application.Interfaces;
using Shop.Application.Primitives.Result;
using Shop.Application.ShopCart.Specifications;
using Shop.Entities.ShopCart;

namespace Shop.Application.ShopCart.UseCases.Write;

public class CreateCartUseCase<Dto>
{
    private readonly IRepository<Cart> _repository;
    private readonly IRepository<Entities.Customer.Account> _accountRepository;
    private readonly IMapper<Dto, Cart> _cartMapper;
    private readonly IDbContext _dbContext;
    private readonly ILogger<CreateCartUseCase<Dto>> _logger;

    public CreateCartUseCase(IRepository<Cart> repository, IDbContext dbContext, ILogger<CreateCartUseCase<Dto>> logger,
        IRepository<Entities.Customer.Account> accountRepository, IMapper<Dto, Cart> cartMapper)
    {
        _repository = repository;
        _dbContext = dbContext;
        _logger = logger;
        _accountRepository = accountRepository;
        _cartMapper = cartMapper;   
    }

    public async Task<Result<string>> ExecuteAsync(Dto dto)
    {
        if (dto is null) throw new ArgumentNullException(nameof(dto));

        try
        {
            var cart = _cartMapper.ToEntity(dto);
            var accountGuid = cart.AccountGuid;

            var account = await _accountRepository.GetByString(accountGuid);

            if (account.HasNoValue)
            {
                return Result.Failure<string>(Errors.Cart.AccountNotFound);
            }

            // TODO: Delete Expired Carts
            var activeCartsSpec = new GetCartsExpiredSpec(cart.AccountGuid, 10);
            await _repository.DeleteBySpecificationAsync(activeCartsSpec);

            await _dbContext.SaveChangesAsync();

            await _repository.AddAsync(cart);
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return Result.Success(cart.Guid);
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
