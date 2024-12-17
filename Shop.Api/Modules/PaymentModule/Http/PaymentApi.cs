using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Payment.UseCases.Read;
using Shop.Infrastructure.Payment.ViewModel;

namespace Shop.Api.Modules.PaymentModule.Http;

public static class PaymentApi
{

    public static IEndpointRouteBuilder MapPaymentApiV1(this IEndpointRouteBuilder app)
    {
        var orderingApi = app.MapGroup("payment")
            .WithTags("Payment");

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
