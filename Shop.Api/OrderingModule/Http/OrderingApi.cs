using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Ordering.UseCases.Read;
using Shop.Infrastructure.Ordering.ViewModel;

namespace Shop.Api.OrderingModule.Http;

public static class OrderingApi
{
    public static IEndpointRouteBuilder MapOrderingApiV1(this IEndpointRouteBuilder app)
    {
        var orderingApi = app.MapGroup("order")
            .WithTags("Order");

        orderingApi.MapGet("payment-types", GetActivePaymentTypes);

        return app;
    }

    public static async Task<Results<Ok<IEnumerable<PaymentTypeViewModel>>, NotFound>> GetActivePaymentTypes(
        [FromServices] GetActivePaymentTypesUseCase<PaymentTypeViewModel> useCase)
    {
        var paytmentTypes = await useCase.ExecuteAsync();

        if (paytmentTypes is null || paytmentTypes.Count() == 0)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(paytmentTypes);
    }

}
