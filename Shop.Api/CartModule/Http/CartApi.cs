using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ConfigModule.Extensions;
using Shop.Api.Filters;
using Shop.Api.Models;
using Shop.Application.Primitives;
using Shop.Application.ShopCart.UseCases.Read;
using Shop.Application.ShopCart.UseCases.Write;
using Shop.Infrastructure.ShopCart.Dtos;
using Shop.Infrastructure.ShopCart.ViewModel;

namespace Shop.Api.CartModule.Http;

public static class CartApi
{
    public static IEndpointRouteBuilder MapCartApiV1(this IEndpointRouteBuilder app)
    {
        var accountApi = app.MapGroup("cart")
            .WithTags("Cart");

        accountApi.MapGet("{cartId}", GetCartByGuid)
            .AddEndpointFilter<RequireProgramFilter>();

        accountApi.MapGet("account/{accountId}", GetActiveCarts)
            .AddEndpointFilter<RequireProgramFilter>();

        accountApi.MapPost("", CreateCart)
            .AddEndpointFilter<RequireProgramFilter>()
            .AddEndpointFilter<FluentValidationFilter<CartDto>>();

        accountApi.MapPost("items/{cartId}", UpdateCartItem)
            .AddEndpointFilter<RequireProgramFilter>()
            .AddEndpointFilter<FluentValidationFilter<CartItemDto>>();

        return app;
    }

    public static async Task<Results<Ok<string>, BadRequest<ApiErrorResponse>>> CreateCart(
        HttpContext context,
        [FromServices] CreateCartUseCase<CartDto> useCase,
        [FromServices] IValidator<CartDto> validator,
        [FromBody] CartDto request)
    {
        var program = context.GetProgramContext();

        var creationResult = await useCase.ExecuteAsync(program.Id, request);

        if (creationResult.IsSuccess)
        {
            return TypedResults.Ok(creationResult.Value);
        }

        return TypedResults.BadRequest(new ApiErrorResponse(creationResult.Error, creationResult.Errors));
    }

    public static async Task<Results<Ok<string>, BadRequest<ApiErrorResponse>>> UpdateCartItem(
        HttpContext context,
       [FromServices] UpdateCartItemUseCase<CartItemDto> useCase,
       [FromServices] IValidator<CartItemDto> validator,
       [FromBody] CartItemDto request,
       [FromRoute] string cartId)
    {
        var program = context.GetProgramContext();

        var creationResult = await useCase.ExecuteAsync(cartId, program.Id, request);

        if (creationResult.IsSuccess)
        {
            return TypedResults.Ok(creationResult.Value);
        }

        return TypedResults.BadRequest(new ApiErrorResponse(creationResult.Error, creationResult.Errors));
    }

    public static async Task<Results<Ok<IEnumerable<CartViewModel>>, NotFound>> GetActiveCarts(
        HttpContext context,
        [FromServices] GetActiveCartsUseCase<CartViewModel> useCase,
        [FromRoute] string accountId)
    {
        var program = context.GetProgramContext();

        var carts = await useCase.ExecuteAsync(accountId, program.Id);

        if (carts is null || carts.Count() == 0)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(carts);
    }

    public static async Task<Results<Ok<CartViewModel>, NotFound>> GetCartByGuid(
        HttpContext context, [FromServices] GetCartByGuidUseCase<CartViewModel> useCase, [FromRoute] string cartId)
    {
        var program = context.GetProgramContext();

        var cart = await useCase.ExecuteAsync(cartId, program.Id);

        if (cart.HasValue)
        {
            return TypedResults.Ok(cart.Value);
        }

        return TypedResults.NotFound();
    }
}
