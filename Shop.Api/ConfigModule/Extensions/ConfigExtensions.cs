using Shop.Infrastructure.Config;

namespace Shop.Api.ConfigModule.Extensions;

public static class ConfigExtensions
{
    public static TenantBuilder<T> AddMultiTenancy<T>(this IServiceCollection services) where T : ProgramContext
        => new(services);

    public static TenantBuilder<ProgramContext> AddMultiTenancy(this IServiceCollection services)
       => new(services);

    public static IApplicationBuilder UseMultiTenancy(this IApplicationBuilder app)
        => app.UseMiddleware<ProgramMiddleware<ProgramContext>>();
}
