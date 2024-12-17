using Shop.Infrastructure.Config;

namespace Shop.Api.Modules.ConfigModule.Extensions;

public static class HttpContextExtensions
{
    public static T? GetProgramContext<T>(this HttpContext httpContext) where T : ProgramContext
    {
        if (!httpContext.Items.ContainsKey(ConfigConstants.HttpContextProgramKey))
            return null;

        return httpContext.Items[ConfigConstants.HttpContextProgramKey] as T;
    }

    public static ProgramContext? GetProgramContext(this HttpContext httpContext) => httpContext.GetProgramContext<ProgramContext>();

}
