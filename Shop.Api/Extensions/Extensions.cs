using Microsoft.EntityFrameworkCore;
using Shop.Application.Catalog.UseCases;
using Shop.Application.Interfaces;
using Shop.Entities.Catalog;
using Shop.Infrastructure;
using Shop.Infrastructure.Catalog.Presenter;
using Shop.Infrastructure.Catalog.Repository;
using Shop.Infrastructure.Catalog.ViewModel;

namespace Shop.Api.Extensions;

public static class Extensions
{
    public static IHostApplicationBuilder AddInfrastructure(this IHostApplicationBuilder app)
    {
        app.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(app.Configuration.GetConnectionString("DefaultConnection"));
        }, ServiceLifetime.Transient);

        app.Services.Configure<ShopSettings>(app.Configuration.GetSection(ShopSettings.SectionName));

        app.Services.AddRepositories();
        app.Services.AddPresenters();
        app.Services.AddUseCases();

        return app;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRepository<Product>, ProductRepository>(); 

        return services;
    }

    public static IServiceCollection AddPresenters(this IServiceCollection services)
    {
        services.AddScoped<IPresenter<Product, ProductViewModel>, ProductPresenter>();

        return services;
    }

    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<GetProductsUseCase<Product, ProductViewModel>>();
        services.AddScoped<GetProductByIdUseCase<Product, ProductViewModel>>();

        return services;
    }

}
