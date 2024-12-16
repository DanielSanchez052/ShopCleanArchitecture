using Shop.Application.Primitives;

namespace Shop.Api.Models;

public class ApiErrorResponse
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiErrorResponse"/> class.
    /// </summary>
    /// <param name="errors">The enumerable collection of errors.</param>
    public ApiErrorResponse(IReadOnlyCollection<Error> errors)
    {
        Errors = errors;
    }

    public ApiErrorResponse(Error error, IReadOnlyCollection<Error>? errors)
    {
        List<Error> res = new()
            {
                error
            };

        if (errors != null)
            res.AddRange(errors.ToList());

        Errors = res;
    }

    /// <summary>
    /// Gets the errors.
    /// </summary>
    public IReadOnlyCollection<Error> Errors { get; }

}
