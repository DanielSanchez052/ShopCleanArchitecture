using Shop.Application.Interfaces;
using Shop.Application.Payment.UseCases.Read;
using Shop.Entities.Payment;
using Shop.Infrastructure.Payment.Presenter;
using Shop.Infrastructure.Payment.Repository;
using Shop.Infrastructure.Payment.ViewModel;

namespace Shop.Api.PaymentModule;

public static class PaymentModuleDI
{
    public static IHostApplicationBuilder AddPaymentModule(this IHostApplicationBuilder app)
    {

        app.Services.AddScoped<IRepository<PaymentType>, PaymentTypeRepository>();
        
        
        app.Services.AddScoped<IPresenter<PaymentType, PaymentTypeViewModel>, PaymentTypePresenter>();
        
        
        app.Services.AddScoped<GetActivePaymentTypesUseCase<PaymentTypeViewModel>>();


        return app;
    }
}
