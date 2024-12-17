using Shop.Api.Models;
using Shop.Api.Modules.ConfigModule.Extensions;
using Shop.Application.Primitives;

namespace Shop.Api.Filters;

public class RequireProgramFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var program = context.HttpContext.GetProgramContext();
        if (program is null)
        {
            return Results.BadRequest(new ApiErrorResponse(new Error("General", "Program not found"), null));
        }

        return await next(context);
    }
}
