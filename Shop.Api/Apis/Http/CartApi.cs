using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Primitives;
using Shop.Application.ShopCart.UseCases.Read;
using Shop.Application.ShopCart.UseCases.Write;
using Shop.Infrastructure.ShopCart.Dtos;
using Shop.Infrastructure.ShopCart.ViewModel;

namespace Shop.Api.Apis.Http;

public static class CartApi
{
    public static IEndpointRouteBuilder MapCartApiV1(this IEndpointRouteBuilder app)
    {
        var accountApi = app.MapGroup("cart");

        accountApi.MapPost("cart", CreateCart);
        accountApi.MapGet("cart/{cartId}", GetCartByGuid);
        accountApi.MapPost("cart/items/{cartId}", UpdateCartItem);
        accountApi.MapGet("cart/account/{accountId}", GetActiveCarts);

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

    public static async Task<Results<Ok<string>, BadRequest<ApiErrorResponse>>> UpdateCartItem(
       [FromServices] UpdateCartItemUseCase<CartItemDto> useCase,
       [FromServices] IValidator<CartItemDto> validator,
       [FromBody] CartItemDto request,
       [FromRoute] string cartId)
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

        var creationResult = await useCase.ExecuteAsync(cartId, request);

        if (creationResult.IsSuccess)
        {
            return TypedResults.Ok(creationResult.Value);
        }

        return TypedResults.BadRequest(new ApiErrorResponse(creationResult.Error, creationResult.Errors));
    }


    public static async Task<Results<Ok<IEnumerable<CartViewModel>>, NotFound>> GetActiveCarts([FromServices] GetActiveCartsUseCase<CartViewModel> useCase, [FromRoute] string accountId)
    {
        var carts = await useCase.ExecuteAsync(accountId);

        if (carts is null || carts.Count() == 0)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(carts);
    }

    public static async Task<Results<Ok<CartViewModel>, NotFound>> GetCartByGuid([FromServices] GetCartByGuidUseCase<CartViewModel> useCase, [FromRoute] string cartId)
    {
        var cart = await useCase.ExecuteAsync(cartId);

        if (cart.HasValue)
        {
            return TypedResults.Ok(cart.Value);
        }

        return TypedResults.NotFound();
    }
}
