using Microsoft.Extensions.Logging;
using Shop.Application.Account.Specifications;
using Shop.Application.Interfaces;
using Shop.Application.Primitives;
using Shop.Application.Primitives.Result;

namespace Shop.Application.Account.UseCases.Write;

public class AddAddressUseCase<TDto>
{
    private readonly IRepository<Entities.Customer.Account> _repository;
    private readonly IMapper<TDto, Entities.Customer.Address> _mapper;
    private readonly IDbContext _dbContext;
    private readonly ILogger<AddAccountUseCase<TDto>> _logger;

    public AddAddressUseCase(IRepository<Entities.Customer.Account> repository, IMapper<TDto, Entities.Customer.Address> mapper, IDbContext dbContext, ILogger<AddAccountUseCase<TDto>> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _dbContext = dbContext;
        _logger = logger;
    }


    public async Task<Result<int>> ExecuteAsync(TDto dto, string accountId, int programId)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));
    

        try
        {
            var errors = new List<Error>();
            var specification = new GetAccountByIdSpecification(accountId, programId);
            var account = await _repository.GetEntityWithSpec(specification);
            if (account == null || account.HasNoValue)
            {
                return Result.Failure<int>(Errors.Account.NotFound);
            }

            var entity = _mapper.ToEntity(dto);
            entity.AccountGuid = accountId;
            account.Value?.AddAddress(entity);

            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return Result.Success<int>(entity.Id);
            }
            else
            {
                return Result.Failure<int>(Errors.Account.CouldNotSave);
            }
        }catch(Exception ex)
        {
            _logger.LogError(string.Format("{0} : {1}", ex.Message, ex.InnerException?.Message));
            return Result.Failure<int>(Errors.Account.CouldNotSave);
        }
    }
}
