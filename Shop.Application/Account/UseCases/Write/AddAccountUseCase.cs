using Microsoft.Extensions.Logging;
using Shop.Application.Account.Specifications;
using Shop.Application.Interfaces;
using Shop.Application.Primitives;
using Shop.Application.Primitives.Result;

namespace Shop.Application.Account.UseCases.Write;

public class AddAccountUseCase<TDto>
{
    private readonly IRepository<Entities.Customer.Account> _repository;
    private readonly IMapper<TDto, Entities.Customer.Account> _mapper;
    private readonly IDbContext _dbContext;
    private readonly ILogger<AddAccountUseCase<TDto>> _logger;

    public AddAccountUseCase(IRepository<Entities.Customer.Account> repository, IMapper<TDto, Entities.Customer.Account> mapper, IDbContext dbContext
        , ILogger<AddAccountUseCase<TDto>> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<Result<string>> ExecuteAsync(TDto dto, int programId)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        try
        {
            var errors = new List<Error>();
            var entity = _mapper.ToEntity(dto) ;

            var specification = new GetAccountByIdSpecification(entity.Guid, programId);
            var account = await _repository.GetEntityWithSpec(specification);
            //if exists create if not update
            if (account.HasNoValue)
            {
                entity.ProgramId = programId;

                await _repository.AddAsync(entity);
            }
            else
            {
                account.Value.Name = entity.Name;
                account.Value.LastName = entity.LastName;
                account.Value.Email = entity.Email;
                account.Value.PhoneNumber = entity.PhoneNumber;
                account.Value.IsActive = entity.IsActive;

                _repository.Update(account.Value);
            }

            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return Result.Success(entity.Guid);
            }

            return Result.Failure<string>(Errors.Account.CouldNotSave);
        }
        catch (Exception ex)
        {
            _logger.LogError(string.Format("{0} : {1}", ex.Message, ex.InnerException?.Message));
            return Result.Failure<string>(Errors.Account.CouldNotSave);
        }
    }

}
