using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Shop.Api;
using Shop.Api.Modules.AccountModule.Http;
using Shop.Api.Modules.CartModule.Http;
using Shop.Api.Modules.CatalogModule.Http;
using Shop.Api.Modules.ConfigModule;
using Shop.Api.Modules.ConfigModule.Extensions;
using Shop.Api.Modules.OrderingModule.Http;
using Shop.Api.Modules.PaymentModule.Http;
using Shop.Infrastructure;
using Shop.Infrastructure.Catalog.Validators;
using Shop.Infrastructure.Config.Presenter;
using Shop.Infrastructure.Seed;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();

builder.Services.AddMultiTenancy()
    .WithResolutionStrategy<ProgramHeaderResolutionStrategy>()
    .WithStore<ProgramContextPresenter>();

builder.AddInfrastructure();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shop.Api", Version = "v1" });
    c.OperationFilter<CustomProgramIdentifierParameter>();

});

//validators
builder.Services.AddValidatorsFromAssemblyContaining<AddProgramProductValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (args.Contains("/seed"))
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var settings = scope.ServiceProvider.GetRequiredService<IOptions<ShopSettings>>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<AppDbContextSeed>>();

    logger.LogInformation("Applying migrations...");
    await new AppDbContextSeed().SeedAsync(context, settings, logger);

    return;
}

app.UseMultiTenancy();

app.MapCatalogApiV1();
app.MapAccountApiV1();
app.MapCartApiV1();
app.MapOrderingApiV1();
app.MapPaymentApiV1();

await app.RunAsync();

