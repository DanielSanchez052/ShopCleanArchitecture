using Shop.Application.Interfaces;
using Shop.Application.Ordering.UseCases.Read;
using Shop.Application.Ordering.UseCases.Write;
using Shop.Entities.Ordering;
using Shop.Entities.ShopCart;
using Shop.Infrastructure.Ordering.Dtos;
using Shop.Infrastructure.Ordering.Mapper;
using Shop.Infrastructure.Ordering.Presenter;
using Shop.Infrastructure.Ordering.Repository;
using Shop.Infrastructure.Ordering.ViewModel;

namespace Shop.Api.Modules.OrderingModule;

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
        services.AddScoped<IRepository<Order>, OrderRepository>();
        return services;
    }

    public static IServiceCollection AddOrderingPresenters(this IServiceCollection services)
    {
        services.AddScoped<IPresenter<Order, OrderCompleteViewModel>, OrderCompletePresenter>();
        services.AddScoped<IPresenter<OrderDetail, OrderDetailViewModel>, OrderDetailPresenter>();
        return services;
    }

    public static IServiceCollection AddOrderingMappers(this IServiceCollection services)
    {
        services.AddScoped<IMapper<OrderDto, Order>, OrderMapper>();
        services.AddScoped<IMapper<CartItem, OrderDetail>, CartToDetailMapper>();
        return services;
    }

    public static IServiceCollection AddOrderingUseCases(this IServiceCollection services)
    {

        services.AddScoped<CreateOrderUseCase<OrderDto>>();
        services.AddScoped<GetOrderHistoryUseCase<OrderCompleteViewModel>>();
        services.AddScoped<ApproveOrderUseCase>();
        services.AddScoped<CancelOrderUseCase>();
        return services;
    }
}
