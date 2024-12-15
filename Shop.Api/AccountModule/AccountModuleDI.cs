using Shop.Application.Account.UseCases.Read;
using Shop.Application.Account.UseCases.Write;
using Shop.Application.Interfaces;
using Shop.Entities.Customer;
using Shop.Infrastructure.Customer.Dtos;
using Shop.Infrastructure.Customer.Mapper;
using Shop.Infrastructure.Customer.Presenter;
using Shop.Infrastructure.Customer.Repository;
using Shop.Infrastructure.Customer.ViewModel;

namespace Shop.Api.AccountModule;

public static class AccountModuleDI
{

    public static IHostApplicationBuilder AddAccountModule(this IHostApplicationBuilder app)
    {
        //Repository
        app.Services.AddScoped<IRepository<Account>, AccountRepository>();

        //Presenters
        app.Services.AddScoped<IPresenter<Account, AccountViewModel>, AccountPresenter>();

        //Mappers
        app.Services.AddScoped<IMapper<AddAccountRequestDto, Account>, AccountMapper>();
        app.Services.AddScoped<IMapper<AddressModel, Address>, AddressMapper>();

        //UseCases
        app.Services.AddScoped<AddAccountUseCase<AddAccountRequestDto>>();
        app.Services.AddScoped<GetAccountUseCase<AccountViewModel>>();
        app.Services.AddScoped<AddAddressUseCase<AddressModel>>();

        return app;
    }

}
