using Microsoft.Extensions.DependencyInjection.Extensions;
using Shop.Application.Config.UseCases.Read;
using Shop.Application.Interfaces;
using Shop.Infrastructure.Config;
using Shop.Infrastructure.Config.Abstractions;

namespace Shop.Api.ConfigModule.Extensions;

public class TenantBuilder<T> where T : ProgramContext
{
    private readonly IServiceCollection _services;

    public TenantBuilder(IServiceCollection services)
    {
        _services = services;
    }

    public TenantBuilder<T> WithResolutionStrategy<V>(ServiceLifetime lifetime = ServiceLifetime.Transient)
        where V : class, IProgramResolutionStrategy
    {
        _services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        _services.Add(ServiceDescriptor.Describe(typeof(IProgramResolutionStrategy), typeof(V), lifetime));
        return this;
    }

    public TenantBuilder<T> WithStore<V>(ServiceLifetime lifetime = ServiceLifetime.Transient)
        where V : class, IPresenter<Entities.Config.Program, T>
    {
        _services.Add(ServiceDescriptor.Describe(typeof(IPresenter<Entities.Config.Program, T>), typeof(V), lifetime));
        _services.Add(ServiceDescriptor.Describe(typeof(GetProgramBySlugUseCase<T>), typeof(GetProgramBySlugUseCase<T>), lifetime));
        return this;
    }

}
