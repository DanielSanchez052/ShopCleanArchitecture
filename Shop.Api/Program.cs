using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Shop.Api.Extensions;
using Shop.Application.Catalog.UseCases;
using Shop.Entities.Catalog;
using Shop.Infrastructure;
using Shop.Infrastructure.Catalog.ViewModel;
using Shop.Infrastructure.Seed;

var builder = WebApplication.CreateBuilder(args);

builder.AddInfrastructure();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.MapGet("/product", async ([FromServices] GetProductsUseCase<Product, ProductViewModel> useCase) =>
{
    return await useCase.ExecuteAsync();
})
.WithName("GetProduct")
.WithOpenApi();

app.MapGet("/product/{id}", async ([FromServices] GetProductByIdUseCase<Product, ProductViewModel> useCase,[FromRoute] string id) =>
{
    return await useCase.ExecuteAsync(id);
})
.WithName("GetProductById")
.WithOpenApi();


await app.RunAsync();

