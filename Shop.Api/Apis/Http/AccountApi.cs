using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Account.UseCases.Write;
using Shop.Application.Primitives;
using Shop.Infrastructure.Customer.Dtos;

namespace Shop.Api.Apis.Http;

public static class AccountApi
{
    public static IEndpointRouteBuilder MapAccountApiV1(this IEndpointRouteBuilder app)
    {
        var accountApi = app.MapGroup("account");

        accountApi.MapPost("account", AddAccount);


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
}
