using Microsoft.EntityFrameworkCore;
using Shop.Api.AccountModule;
using Shop.Api.CartModule;
using Shop.Api.CatalogModule;
using Shop.Api.ConfigModule;
using Shop.Api.OrderingModule;
using Shop.Api.PaymentModule;
using Shop.Application.Interfaces;
using Shop.Application.Security.Services;
using Shop.Infrastructure;
using Shop.Infrastructure.Config.Repository;
using Shop.Infrastructure.Security.Services;

namespace Shop.Api;

public static class Extensions
{
    public static IHostApplicationBuilder AddInfrastructure(this IHostApplicationBuilder app)
    {
        app.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(app.Configuration.GetConnectionString("DefaultConnection"));
        });

        app.Services.Configure<ShopSettings>(app.Configuration.GetSection(ShopSettings.SectionName));

        app.Services.AddScoped<IDbContext>(serviceProvider => serviceProvider.GetRequiredService<AppDbContext>());

        app.AddCatalogModule();
        app.AddAccountModule();
        app.AddCartModule();
        app.AddOrderingModule();
        app.AddPaymentModule();
        app.AddConfigModule();
        app.Services.AddServices();

        return app;
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
