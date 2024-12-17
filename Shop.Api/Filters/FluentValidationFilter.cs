
using FluentValidation;
using Shop.Api.Models;
using Shop.Application.Primitives;

namespace Shop.Api.Filters
{
    public class FluentValidationFilter<T> : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var validator = context.HttpContext.RequestServices.GetRequiredService<IValidator<T>>();
            if (validator is not null)
            {
                var model = context.Arguments.OfType<T>().FirstOrDefault(a => a?.GetType() == typeof(T));
                if (model is not null)
                {
                    var validationResult = validator.Validate(model);

                    if (!validationResult.IsValid)
                    {
                        Error[] errors = validationResult.Errors
                            .Select(f => new Error(f.ErrorCode, f.ErrorMessage))
                            .Distinct()
                            .ToArray();

                        return Results.BadRequest(new ApiErrorResponse(new Error("General", "Validation error"), errors));

                    }
                }
                else
                {
                    return Results.BadRequest(new ApiErrorResponse(new Error("General", "body cannot be null"), null));
                }
            }

            return await next(context);
        }
    }
}
