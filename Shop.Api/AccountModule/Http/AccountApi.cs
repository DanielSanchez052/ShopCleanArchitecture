using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Apis;
using Shop.Application.Account;
using Shop.Application.Account.UseCases.Read;
using Shop.Application.Account.UseCases.Write;
using Shop.Application.Primitives;
using Shop.Infrastructure.Customer.Dtos;
using Shop.Infrastructure.Customer.ViewModel;

namespace Shop.Api.AccountModule.Http;

public static class AccountApi
{
    public static IEndpointRouteBuilder MapAccountApiV1(this IEndpointRouteBuilder app)
    {
        var accountApi = app.MapGroup("account");

        accountApi.MapPost("account", AddAccount);
        accountApi.MapGet("account/{accountId}", GetAccountById);
        accountApi.MapPost("account/{accountId}/address", AddAddress);

        return app;
    }


    public static async Task<Results<Ok<string>, BadRequest<ApiErrorResponse>>> AddAccount(
       [FromServices] AddAccountUseCase<AddAccountRequestDto> useCase,
       [FromServices] IValidator<AddAccountRequestDto> validator,
       [FromBody] AddAccountRequestDto account
       )
    {
        if (account == null)
        {
            return TypedResults.BadRequest(new ApiErrorResponse(new Error("General", "body cannot be null"), null));
        }

        var result = await validator.ValidateAsync(account);
        if (!result.IsValid)
        {
            Error[] errors = result.Errors
                .Select(f => new Error(f.ErrorCode, f.ErrorMessage))
                .Distinct()
                .ToArray();

            return TypedResults.BadRequest(new ApiErrorResponse(new Error("General", "Validation error"), errors));
        }

        var creationResult = await useCase.ExecuteAsync(account);

        if (creationResult.IsSuccess)
        {
            return TypedResults.Ok(creationResult.Value);
        }

        return TypedResults.BadRequest(new ApiErrorResponse(creationResult.Error, creationResult.Errors));
    }

    public static async Task<Results<Ok<int>, BadRequest<ApiErrorResponse>>> AddAddress(
       [FromServices] AddAddressUseCase<AddressModel> useCase,
       [FromBody] AddressModel address,
       [FromRoute] string accountId
       )
    {
        if (address == null)
        {
            return TypedResults.BadRequest(new ApiErrorResponse(new Error("General", "body cannot be null"), null));
        }

        if (string.IsNullOrEmpty(address.RawValue) && string.IsNullOrEmpty(address.Street) && string.IsNullOrEmpty(address.City) && string.IsNullOrEmpty(address.HouseNumber))
        {
            return TypedResults.BadRequest(new ApiErrorResponse(new Error("General", "Validation error"), [Errors.Address.Empty]));
        }

        var creationResult = await useCase.ExecuteAsync(address, accountId);

        if (creationResult.IsSuccess)
        {
            return TypedResults.Ok(creationResult.Value);
        }

        return TypedResults.BadRequest(new ApiErrorResponse(creationResult.Error, creationResult.Errors));
    }

    public static async Task<Results<Ok<AccountViewModel>, NotFound>> GetAccountById([FromServices] GetAccountUseCase<AccountViewModel> useCase, [FromRoute] string accountId)
    {
        var account = await useCase.ExecuteAsync(accountId);

        if (account.HasValue)
        {
            return TypedResults.Ok(account.Value);
        }

        return TypedResults.NotFound();
    }

}
