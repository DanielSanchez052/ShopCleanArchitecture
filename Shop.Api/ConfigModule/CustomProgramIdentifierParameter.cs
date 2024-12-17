using Microsoft.OpenApi.Models;
using Shop.Infrastructure.Config;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Shop.Api.ConfigModule;

public class CustomProgramIdentifierParameter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = ConfigConstants.ProgramIdentifierHeaderName,
            In = ParameterLocation.Header,
            Description = "Custom header for program identification",
            Required = true
        });
    }
}
