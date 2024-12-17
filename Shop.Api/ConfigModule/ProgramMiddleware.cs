using Shop.Application.Config.UseCases.Read;
using Shop.Infrastructure.Config;
using Shop.Infrastructure.Config.Abstractions;

namespace Shop.Api.ConfigModule;

public class ProgramMiddleware<T> where T : ProgramContext
{
    private readonly RequestDelegate _next;

    public ProgramMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Items.ContainsKey(ConfigConstants.HttpContextProgramKey))
        {
            var getProgram = context.RequestServices.GetService(typeof(GetProgramBySlugUseCase<T>)) as GetProgramBySlugUseCase<T>;
            var programResolution = context.RequestServices.GetService(typeof(IProgramResolutionStrategy)) as IProgramResolutionStrategy;
        
            var identifier = await programResolution?.GetProgramIdentifierAsync();
            if(identifier != null)
            {
                var programContext = await getProgram?.ExecuteAsync(identifier);
                if(programContext != null)
                    context.Items.Add(ConfigConstants.HttpContextProgramKey, programContext);
            }
        }

        if(_next != null)
            await _next(context);
    }

}
