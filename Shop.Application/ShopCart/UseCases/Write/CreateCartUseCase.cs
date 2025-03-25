using Microsoft.Extensions.Logging;
using Shop.Application.Account.Specifications;
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

    public async Task<Result<string>> ExecuteAsync(int programId,Dto dto)
    {
        if (dto is null) throw new ArgumentNullException(nameof(dto));

        try
        {
            int expirationDays = 10;
            var cart = _cartMapper.ToEntity(dto);
            var accountGuid = cart.AccountGuid;

            var accountSpec = new GetAccountByIdSpecification(accountGuid, programId);
            var account = await _accountRepository.GetEntityWithSpec(accountSpec);

            if (account.HasNoValue)
            {
                return Result.Failure<string>(Errors.Cart.AccountNotFound);
            }

            var accountCartsSpec = new GetCartsByAccountSpec(cart.AccountGuid);

            var carts = await _repository.ListAsync(accountCartsSpec);

            if (carts != null && carts.Count > 0)
            {
                var activeCart = carts.Where(c => !c.IsExpired(expirationDays)).OrderBy(c => c.CreateDate).FirstOrDefault();

                var expiredCarts = carts.Where(c => c.Guid != activeCart.Guid).ToList();

                cart = activeCart;

                _repository.DeleteRange(expiredCarts);
            }
            else
            {
                await _repository.AddAsync(cart);

                var result = await _dbContext.SaveChangesAsync();
                if (result <= 0)
                {
                    return Result.Failure<string>(Errors.Cart.CouldNotSave);
                }

            }
            return Result.Success(cart.Guid);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating cart");
            return Result.Failure<string>(Errors.Cart.CouldNotSave);
        }
    }
}
