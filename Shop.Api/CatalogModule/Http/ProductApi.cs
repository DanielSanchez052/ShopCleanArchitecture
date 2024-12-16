using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Catalog.UseCases.Read;
using Shop.Application.Catalog;
using Shop.Application;
using Shop.Infrastructure.Catalog.ViewModel;
using FluentValidation;
using Shop.Application.Catalog.UseCases.Write;
using Shop.Infrastructure.Catalog.Dtos;
using Shop.Application.Primitives;
using Shop.Api.Models;

namespace Shop.Api.CatalogModule.Http;

public static class ProductApi
{
    public static RouteGroupBuilder MapProductApiV1 (this RouteGroupBuilder group)
    {
        var productApi = group.MapGroup("product").WithTags("Product");

        productApi.MapGet("/", GetProducts);
        productApi.MapGet("/{productCode}", GetProductById);
        //productApi.MapPost("", AddProduct);

        productApi.MapGet("product-type/", GetProductTypes);
        productApi.MapGet("category", GetCategories);

        return group;
    }

    public static async Task<Results<Ok<PagedList<ProductViewModel>>, NotFound>> GetProducts([FromServices] GetProductsByFilterUseCase<ProductViewModel> useCase, [AsParameters] ProductFilterParams filters)
    {
        var products = await useCase.ExecuteAsync(filters);

        return TypedResults.Ok(products);
    }

    public static async Task<Results<Ok<ProductViewModel>, NotFound>> GetProductById([FromServices] GetProductByIdUseCase<ProductViewModel> useCase, [FromRoute] string productCode)
    {
        var product = await useCase.ExecuteAsync(productCode);

        if (product.HasValue)
        {
            return TypedResults.Ok(product.Value);
        }

        return TypedResults.NotFound();
    }

    public static async Task<Results<Ok<string>, BadRequest<ApiErrorResponse>>> AddProduct(
         [FromServices] AddProductUseCase<AddProductRequestDto> useCase,
         [FromServices] IValidator<AddProductRequestDto> validator,
         [FromBody] AddProductRequestDto product
     )
    {
        if (product == null)
        {
            return TypedResults.BadRequest(new ApiErrorResponse(new Error("General", "body cannot be null"), null));
        }

        var result = await validator.ValidateAsync(product);
        if (!result.IsValid)
        {
            Error[] errors = result.Errors
                .Select(f => new Error(f.ErrorCode, f.ErrorMessage))
                .Distinct()
                .ToArray();

            return TypedResults.BadRequest(new ApiErrorResponse(new Error("General", "Validation error"), errors));
        }

        var creationResult = await useCase.ExecuteAsync(product);

        if (creationResult.IsSuccess)
        {
            return TypedResults.Ok(creationResult.Value);
        }

        return TypedResults.BadRequest(new ApiErrorResponse(creationResult.Error, creationResult.Errors));
    }

    public static async Task<Results<Ok<List<ProductTypeViewModel>>, NotFound>> GetProductTypes([FromServices] GetProductTypesUseCase<ProductTypeViewModel> useCase)
    {
        var productTypes = await useCase.ExecuteAsync();

        return TypedResults.Ok(productTypes.ToList());
    }

    public static async Task<Results<Ok<IEnumerable<CategoryViewModel>>, NotFound>> GetCategories([FromServices] GetCategories<CategoryViewModel> useCase, [FromHeader] string? programId)
    {
        if (programId == null || !int.TryParse(programId, out int program))
        {
            return TypedResults.NotFound();
        }

        var product = await useCase.ExecuteAsync(program);

        if (product != null)
        {
            return TypedResults.Ok(product);
        }

        return TypedResults.NotFound();
    }
}
