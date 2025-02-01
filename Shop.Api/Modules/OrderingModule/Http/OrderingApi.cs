using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Models;
using Shop.Api.Modules.ConfigModule.Extensions;
using Shop.Application.Catalog.UseCases.Read;
using Shop.Application.Catalog;
using Shop.Application;
using Shop.Application.Ordering.UseCases.Write;
using Shop.Application.ShopCart.UseCases.Write;
using Shop.Infrastructure.Catalog.ViewModel;
using Shop.Infrastructure.Ordering.Dtos;
using Shop.Infrastructure.ShopCart.Dtos;
using Shop.Application.Ordering.UseCases.Read;
using Shop.Infrastructure.Ordering.ViewModel;
using Shop.Application.Ordering;
using Shop.Api.Filters;

namespace Shop.Api.Modules.OrderingModule.Http;

public static class OrderingApi
{
    public static IEndpointRouteBuilder MapOrderingApiV1(this IEndpointRouteBuilder app)
    {
        var orderingApi = app.MapGroup("order")
            .WithTags("Order");

        orderingApi.MapPost("/", CreateOrder).AddEndpointFilter<RequireProgramFilter>();
        orderingApi.MapGet("/history", GetOrderHistory).AddEndpointFilter<RequireProgramFilter>();


        return app;
    }

    public static async Task<Results<Ok<string>, BadRequest<ApiErrorResponse>>> CreateOrder(
        HttpContext context,
        [FromServices] CreateOrderUseCase<OrderDto> useCase,
        [FromServices] IValidator<OrderDto> validator,
        [FromBody] OrderDto request)
    {
        var program = context.GetProgramContext();

        var creationResult = await useCase.ExecuteAsync(request, program.Id);

        if (creationResult.IsSuccess)
        {
            return TypedResults.Ok(creationResult.Value);
        }

        return TypedResults.BadRequest(new ApiErrorResponse(creationResult.Error, creationResult.Errors));
    }

    public static async Task<Results<Ok<PagedList<OrderCompleteViewModel>>, NotFound>> GetOrderHistory(
        HttpContext context,
        [FromServices] GetOrderHistoryUseCase<OrderCompleteViewModel> useCase, 
        [AsParameters] OrderHistoryFilterParams filters)
    {
        var program = context.GetProgramContext();

        var orders = await useCase.ExecuteAsync(filters, filters.AccountId, program?.Id ?? 0);

        return TypedResults.Ok(orders);
    }


}
