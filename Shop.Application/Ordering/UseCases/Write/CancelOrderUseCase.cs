using Microsoft.Extensions.Logging;
using Shop.Application.Interfaces;
using Shop.Application.Ordering.Specifications;
using Shop.Application.Primitives;
using Shop.Application.Primitives.Result;
using Shop.Entities.Ordering;
using System.ComponentModel.DataAnnotations;

namespace Shop.Application.Ordering.UseCases.Write;

public class CancelOrderUseCase
{
    private readonly ILogger<CancelOrderUseCase> _logger;
    private readonly IRepository<Order> _repository;
    private readonly IDbContext _context;

    public CancelOrderUseCase(ILogger<CancelOrderUseCase> logger, IRepository<Order> repository, IDbContext context)
    {
        _logger = logger;
        _repository = repository;
        _context = context;
    }

    public async Task<Result<bool>> ExecuteAsync(string orderNumber, int programId)
    {
        if (string.IsNullOrWhiteSpace(orderNumber))
            throw new ArgumentNullException(nameof(orderNumber));

        try
        {
            var errors = new List<Error>();
            var getOrderSpec = new GetOrderSpecification(orderNumber, programId);
            var orderMaybe = await _repository.GetEntityWithSpec(getOrderSpec);

            if (orderMaybe.HasNoValue) 
                return Result.Failure<bool>(Errors.Order.NotFound);

            var order = orderMaybe.Value;

            if(order?.CanCancel() == true)
            {
                order?.Cancel();

                _repository.Update(order);

                var rows = await _context.SaveChangesAsync();

                if (rows == 0)
                    return Result.Failure<bool>(Errors.Order.CouldNotSave);

                return Result.Success(true);
            }
            
            return Result.Failure<bool>(Errors.Order.CouldNotCancel);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error approving order");
            return Result.Failure<bool>(Errors.Order.CouldNotCancel);
        }

    }
}
