using Shop.Application.Interfaces;
using Shop.Application.ShopCart.UseCases.Read;
using Shop.Application.ShopCart.UseCases.Write;
using Shop.Entities.ShopCart;
using Shop.Infrastructure.ShopCart.Dtos;
using Shop.Infrastructure.ShopCart.Mapper;
using Shop.Infrastructure.ShopCart.Presenter;
using Shop.Infrastructure.ShopCart.Repository;
using Shop.Infrastructure.ShopCart.ViewModel;

namespace Shop.Api.CartModule;

public static class CartModuleDI
{
    public static IHostApplicationBuilder AddCartModule(this IHostApplicationBuilder app)
    {
        //Repository
        app.Services.AddScoped<IRepository<Cart>, CartRepository>();
        app.Services.AddScoped<IRepository<CartItem>, CartitemRepository>();

        //Presenters
        app.Services.AddScoped<IPresenter<Cart, CartViewModel>, CartPresenter>();

        //Mappers
        app.Services.AddScoped<IMapper<CartItemDto, CartItem>, CartItemMapper>();
        app.Services.AddScoped<IMapper<CartDto, Cart>, CartMapper>();

        //UseCases
        app.Services.AddScoped<CreateCartUseCase<CartDto>>();
        app.Services.AddScoped<GetActiveCartsUseCase<CartViewModel>>();
        app.Services.AddScoped<GetCartByGuidUseCase<CartViewModel>>();
        app.Services.AddScoped<UpdateCartItemUseCase<CartItemDto>>();

        return app;
    }
}
