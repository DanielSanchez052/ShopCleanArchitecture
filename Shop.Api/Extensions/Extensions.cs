using Microsoft.EntityFrameworkCore;
using Shop.Application.Catalog.Specifications;
using Shop.Application.Catalog.UseCases;
using Shop.Application.Interfaces;
using Shop.Entities.Catalog;
using Shop.Entities.Config;
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

        app.Services.AddScoped<IDbContext>(serviceProvider => serviceProvider.GetRequiredService<AppDbContext>());

        app.Services.AddRepositories();
        app.Services.AddPresenters();
        app.Services.AddUseCases();

        return app;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRepository<Product>, ProductRepository>(); 
        services.AddScoped<IRepository<ProgramProduct>, ProgramProductRepository>();
        services.AddScoped<IRepository<Category>, CategoryRepository>();

        return services;
    }

    public static IServiceCollection AddPresenters(this IServiceCollection services)
    {
        services.AddScoped<IPresenter<Product, ProductViewModel>, ProductPresenter>();
        services.AddScoped<IPresenter<ProgramProduct, ProgramProductViewModel>, ProgramProductPresenter>();
        services.AddScoped<IPresenter<Category, CategoryViewModel>, CategoryPresenter>();

        return services;
    }

    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<GetProductsByFilterUseCase<ProductViewModel>>();
        services.AddScoped<GetProductByIdUseCase<ProductViewModel>>();
        services.AddScoped<GetProgramProductsByFilterUseCase<ProgramProductViewModel>>();
        services.AddScoped<GetProgramProductsByCodeUseCase<ProgramProductViewModel>>();
        services.AddScoped<GetCategories<CategoryViewModel>>();

        return services;
    }

}
