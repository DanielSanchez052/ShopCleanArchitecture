using Shop.Application.Catalog.UseCases.Read;
using Shop.Application.Catalog.UseCases.Write;
using Shop.Application.Interfaces;
using Shop.Entities.Catalog;
using Shop.Infrastructure.Catalog.Dtos;
using Shop.Infrastructure.Catalog.Mapper;
using Shop.Infrastructure.Catalog.Presenter;
using Shop.Infrastructure.Catalog.Repository;
using Shop.Infrastructure.Catalog.ViewModel;

namespace Shop.Api.Modules.CatalogModule;

public static class CatalogModuleDI
{
    public static IHostApplicationBuilder AddCatalogModule(this IHostApplicationBuilder app)
    {
        app.Services.AddCatalogRepositories();
        app.Services.AddCatalogPresenters();
        app.Services.AddCatalogMappers();
        app.Services.AddCatalogUseCases();

        return app;
    }

    public static IServiceCollection AddCatalogRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRepository<Product>, ProductRepository>();
        services.AddScoped<IRepository<ProductType>, ProductTypeRepository>();
        services.AddScoped<IRepository<ProgramProduct>, ProgramProductRepository>();
        services.AddScoped<IRepository<Category>, CategoryRepository>();
        services.AddScoped<IRepository<ProgramProductReference>, ProgramProductReferenceRepository>();

        return services;
    }

    public static IServiceCollection AddCatalogPresenters(this IServiceCollection services)
    {
        services.AddScoped<IPresenter<Product, ProductViewModel>, ProductPresenter>();
        services.AddScoped<IPresenter<ProgramProduct, ProgramProductViewModel>, ProgramProductPresenter>();
        services.AddScoped<IPresenter<Category, CategoryViewModel>, CategoryPresenter>();
        services.AddScoped<IPresenter<ProductType, ProductTypeViewModel>, ProductTypePresenter>();
        return services;
    }

    public static IServiceCollection AddCatalogMappers(this IServiceCollection services)
    {
        services.AddScoped<IMapper<AddProgramProductRequestDto, ProgramProduct>, ProgramProductMapper>();
        services.AddScoped<IMapper<AddProductRequestDto, Product>, ProductMapper>();
        services.AddScoped<IMapper<AddProductReferenceRequestDto, ProgramProductReference>, ProgramProductReferenceMapper>();

        return services;
    }

    public static IServiceCollection AddCatalogUseCases(this IServiceCollection services)
    {
        services.AddScoped<GetProductsByFilterUseCase<ProductViewModel>>();
        services.AddScoped<GetProductByIdUseCase<ProductViewModel>>();
        services.AddScoped<GetProgramProductsByFilterUseCase<ProgramProductViewModel>>();
        services.AddScoped<GetProgramProductsByCodeUseCase<ProgramProductViewModel>>();
        services.AddScoped<GetCategories<CategoryViewModel>>();
        services.AddScoped<GetProductTypesUseCase<ProductTypeViewModel>>();
        services.AddScoped<AddProductToProgramUseCase<AddProgramProductRequestDto>>();
        services.AddScoped<AddProductUseCase<AddProductRequestDto>>();
        services.AddScoped<AddProductReferenceUseCase<AddProductReferenceRequestDto>>();

        return services;
    }

}
