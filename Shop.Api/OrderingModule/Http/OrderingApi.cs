using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Payment.UseCases.Read;
using Shop.Infrastructure.Payment.ViewModel;

namespace Shop.Api.OrderingModule.Http;

public static class OrderingApi
{
    public static IEndpointRouteBuilder MapOrderingApiV1(this IEndpointRouteBuilder app)
    {
        var orderingApi = app.MapGroup("order")
            .WithTags("Order");


        return app;
    }

    

}
