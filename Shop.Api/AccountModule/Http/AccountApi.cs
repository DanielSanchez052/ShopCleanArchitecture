using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ConfigModule.Extensions;
using Shop.Api.Filters;
using Shop.Api.Models;
using Shop.Application.Account.UseCases.Read;
using Shop.Application.Account.UseCases.Write;
using Shop.Infrastructure.Customer.Dtos;
using Shop.Infrastructure.Customer.ViewModel;

namespace Shop.Api.AccountModule.Http;

public static class AccountApi
{
    public static IEndpointRouteBuilder MapAccountApiV1(this IEndpointRouteBuilder app)
    {
        var accountApi = app.MapGroup("account")
            .WithTags("Account");

        accountApi.MapPost("", AddAccount)
            .AddEndpointFilter<RequireProgramFilter>()
            .AddEndpointFilter<FluentValidationFilter<AddAccountRequestDto>>();

        accountApi.MapGet("{accountId}", GetAccountById).AddEndpointFilter<RequireProgramFilter>();
        accountApi.MapPost("{accountId}/address", AddAddress)
            .AddEndpointFilter<RequireProgramFilter>()
            .AddEndpointFilter<FluentValidationFilter<AddressModel>>(); ;

        return app;
    }


    public static async Task<Results<Ok<string>, BadRequest<ApiErrorResponse>>> AddAccount(
       HttpContext context,
       [FromServices] AddAccountUseCase<AddAccountRequestDto> useCase,
       [FromServices] IValidator<AddAccountRequestDto> validator,
       [FromBody] AddAccountRequestDto account
       )
    {
        var programContext = context.GetProgramContext();

        var creationResult = await useCase.ExecuteAsync(account, programContext.Id);

        if (creationResult.IsSuccess)
        {
            return TypedResults.Ok(creationResult.Value);
        }

        return TypedResults.BadRequest(new ApiErrorResponse(creationResult.Error, creationResult.Errors));
    }

    public static async Task<Results<Ok<int>, BadRequest<ApiErrorResponse>>> AddAddress(
        HttpContext context,
       [FromServices] AddAddressUseCase<AddressModel> useCase,
       [FromBody] AddressModel address,
       [FromRoute] string accountId
       )
    {
        var programContext = context.GetProgramContext();

        var creationResult = await useCase.ExecuteAsync(address, accountId, programContext.Id);

        if (creationResult.IsSuccess)
        {
            return TypedResults.Ok(creationResult.Value);
        }

        return TypedResults.BadRequest(new ApiErrorResponse(creationResult.Error, creationResult.Errors));
    }

    public static async Task<Results<Ok<AccountViewModel>, NotFound>> GetAccountById(
        HttpContext context,
        [FromServices] GetAccountUseCase<AccountViewModel> useCase, [FromRoute] string accountId)
    {
        var programContext = context.GetProgramContext();

        var account = await useCase.ExecuteAsync(accountId, programContext.Id);

        if (account.HasValue)
        {
            return TypedResults.Ok(account.Value);
        }

        return TypedResults.NotFound();
    }

}
