using Shop.Application.Catalog.UseCases.Read;
using Shop.Application.Catalog.UseCases.Write;
using Shop.Application.Interfaces;
using Shop.Application.Payment.UseCases.Read;
using Shop.Entities.Catalog;
using Shop.Entities.Ordering;
using Shop.Infrastructure.Catalog.Dtos;
using Shop.Infrastructure.Catalog.Mapper;
using Shop.Infrastructure.Catalog.Presenter;
using Shop.Infrastructure.Catalog.Repository;
using Shop.Infrastructure.Catalog.ViewModel;
using Shop.Infrastructure.Payment.Presenter;
using Shop.Infrastructure.Payment.Repository;
using Shop.Infrastructure.Payment.ViewModel;

namespace Shop.Api.OrderingModule;

public static class OrderingModuleDI
{
    public static IHostApplicationBuilder AddOrderingModule(this IHostApplicationBuilder app)
    {

        app.Services.AddOrderingRepositories();
        app.Services.AddOrderingPresenters();
        app.Services.AddOrderingMappers();
        app.Services.AddOrderingUseCases();

        return app;
    }

    public static IServiceCollection AddOrderingRepositories(this IServiceCollection services)
    {

        return services;
    }

    public static IServiceCollection AddOrderingPresenters(this IServiceCollection services)
    {

        return services;
    }

    public static IServiceCollection AddOrderingMappers(this IServiceCollection services)
    {

        return services;
    }

    public static IServiceCollection AddOrderingUseCases(this IServiceCollection services)
    {

        return services;
    }
}
