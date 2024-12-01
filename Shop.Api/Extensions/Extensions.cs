using Microsoft.EntityFrameworkCore;
using Shop.Application.Account.UseCases.Write;
using Shop.Application.Catalog.UseCases.Read;
using Shop.Application.Catalog.UseCases.Write;
using Shop.Application.Interfaces;
using Shop.Application.Security.Services;
using Shop.Entities.Catalog;
using Shop.Entities.Customer;
using Shop.Infrastructure;
using Shop.Infrastructure.Catalog.Dtos;
using Shop.Infrastructure.Catalog.Mapper;
using Shop.Infrastructure.Catalog.Presenter;
using Shop.Infrastructure.Catalog.Repository;
using Shop.Infrastructure.Catalog.ViewModel;
using Shop.Infrastructure.Config.Repository;
using Shop.Infrastructure.Customer.Dtos;
using Shop.Infrastructure.Customer.Mapper;
using Shop.Infrastructure.Customer.Repository;
using Shop.Infrastructure.Security.Services;

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
        app.Services.AddMappers();
        app.Services.AddServices();

        return app;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRepository<Product>, ProductRepository>();
        services.AddScoped<IRepository<ProductType>, ProductTypeRepository>();
        services.AddScoped<IRepository<ProgramProduct>, ProgramProductRepository>();
        services.AddScoped<IRepository<Category>, CategoryRepository>();
        services.AddScoped<IRepository<Entities.Config.Program>, ProgramRepository>();
        services.AddScoped<IRepository<ProgramProductReference>, ProgramProductReferenceRepository>();
        services.AddScoped<IRepository<Account>, AccountRepository>();

        return services;
    }

    public static IServiceCollection AddPresenters(this IServiceCollection services)
    {
        services.AddScoped<IPresenter<Product, ProductViewModel>, ProductPresenter>();
        services.AddScoped<IPresenter<ProgramProduct, ProgramProductViewModel>, ProgramProductPresenter>();
        services.AddScoped<IPresenter<Category, CategoryViewModel>, CategoryPresenter>();
        services.AddScoped<IPresenter<ProductType, ProductTypeViewModel>, ProductTypePresenter>();

        return services;
    }

    public static IServiceCollection AddMappers(this IServiceCollection services)
    {
        services.AddScoped<IMapper<AddProgramProductRequestDto, ProgramProduct>, ProgramProductMapper>();
        services.AddScoped<IMapper<AddProductRequestDto, Product>, ProductMapper>();
        services.AddScoped<IMapper<AddProductReferenceRequestDto, ProgramProductReference>, ProgramProductReferenceMapper>();
        services.AddScoped<IMapper<AddAccountRequestDto, Account>, AccountMapper>();
        return services;
    }

    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        //Catalog
        services.AddScoped<GetProductsByFilterUseCase<ProductViewModel>>();
        services.AddScoped<GetProductByIdUseCase<ProductViewModel>>();
        services.AddScoped<GetProgramProductsByFilterUseCase<ProgramProductViewModel>>();
        services.AddScoped<GetProgramProductsByCodeUseCase<ProgramProductViewModel>>();
        services.AddScoped<GetCategories<CategoryViewModel>>();
        services.AddScoped<GetProductTypesUseCase<ProductTypeViewModel>>();
        services.AddScoped<AddProductToProgramUseCase<AddProgramProductRequestDto>>();
        services.AddScoped<AddProductUseCase<AddProductRequestDto>>();
        services.AddScoped<AddProductReferenceUseCase<AddProductReferenceRequestDto>>();

        //Account
        services.AddScoped<AddAccountUseCase<AddAccountRequestDto>>();
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        // Inyectar la implementación del servicio
        string encryptionKey = "qwBvZEd4ZW5kUGNmZEdXN1lhRWp5Y2k=";
        string initializationVector = "Z2drTGpkM0E9PQ==";

        services.AddSingleton<IEncryptionService>(provider => new EncryptionService(encryptionKey, initializationVector));

        return services;
    }

}
