using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Options;
using Shop.Api.Apis.Http;
using Shop.Api.Extensions;
using Shop.Application.Catalog.Validators;
using Shop.Infrastructure;
using Shop.Infrastructure.Seed;

var builder = WebApplication.CreateBuilder(args);

builder.AddInfrastructure();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.MapCatalogApiV1();
app.MapAccountApiV1();
app.MapCartApiV1();

await app.RunAsync();

