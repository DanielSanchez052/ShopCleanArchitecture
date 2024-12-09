using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Primitives;
using Shop.Application.ShopCart.UseCases.Write;
using Shop.Infrastructure.Customer.Dtos;
using Shop.Infrastructure.ShopCart.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Shop.Api.Apis.Http;

public static class CartApi
{
    public static IEndpointRouteBuilder MapCartApiV1(this IEndpointRouteBuilder app)
    {
        var accountApi = app.MapGroup("cart");

        accountApi.MapPost("cart", CreateCart);

        return app;
    }


    public static async Task<Results<Ok<string>, BadRequest<ApiErrorResponse>>> CreateCart(
        [FromServices] CreateCartUseCase<CartDto> useCase,
        [FromServices] IValidator<CartDto> validator,
        [FromBody] CartDto request)
    {
        if (request == null)
        {
            return TypedResults.BadRequest(new ApiErrorResponse(new Error("General", "body cannot be null"), null));
        }

        var result = await validator.ValidateAsync(request);
        if (!result.IsValid)
        {
            Error[] errors = result.Errors
                .Select(f => new Error(f.ErrorCode, f.ErrorMessage))
                .Distinct()
                .ToArray();

            return TypedResults.BadRequest(new ApiErrorResponse(new Error("General", "Validation error"), errors));
        }


        var creationResult = await useCase.ExecuteAsync(request);

        if (creationResult.IsSuccess)
        {
            return TypedResults.Ok(creationResult.Value);
        }

        return TypedResults.BadRequest(new ApiErrorResponse(creationResult.Error, creationResult.Errors));
    }
}
