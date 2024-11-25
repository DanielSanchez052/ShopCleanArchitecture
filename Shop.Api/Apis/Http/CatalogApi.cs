using Azure.Core;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shop.Application;
using Shop.Application.Catalog;
using Shop.Application.Catalog.UseCases.Read;
using Shop.Application.Catalog.UseCases.Write;
using Shop.Application.Primitives;
using Shop.Entities.Catalog;
using Shop.Infrastructure.Catalog.Dtos;
using Shop.Infrastructure.Catalog.ViewModel;

namespace Shop.Api.Apis.Http;

public  static class CatalogApi
{
    public static IEndpointRouteBuilder MapCatalogApiV1(this IEndpointRouteBuilder app)
    {
        var catalogApi = app.MapGroup("catalog");

        catalogApi.MapGet("product/", GetProducts);
        catalogApi.MapGet("product/{id}", GetProductById);
        catalogApi.MapPost("product", AddProduct);
        catalogApi.MapGet("program-product/", GetProgramProducts);
        catalogApi.MapGet("program-product/{productCode}", GetProgramProductByCode);
        catalogApi.MapGet("category", GetCategories);
        catalogApi.MapPost("program-product", AddProgramProduct);
        

        return app;
    }


    public static async Task<Results<Ok<PagedList<ProductViewModel>>, NotFound>> GetProducts([FromServices] GetProductsByFilterUseCase<ProductViewModel> useCase, [AsParameters] ProductFilterParams filters)
    {
        var products = await useCase.ExecuteAsync(filters);

        return TypedResults.Ok(products);
    }

    public static async Task<Results<Ok<ProductViewModel>, NotFound>> GetProductById([FromServices] GetProductByIdUseCase<ProductViewModel> useCase, [FromRoute] string id)
    {
        var product = await useCase.ExecuteAsync(id);

        if (product != null)
        {
            return TypedResults.Ok(product);
        }

        return TypedResults.NotFound();
    }

    public static async Task<Results<Ok<PagedList<ProgramProductViewModel>>, NotFound>> GetProgramProducts([FromServices] GetProgramProductsByFilterUseCase<ProgramProductViewModel> useCase, [AsParameters] ProgramProductFilterParams filters)
    {
        var product = await useCase.ExecuteAsync(filters);

        if (product != null)
        {
            return TypedResults.Ok(product);
        }

        return TypedResults.NotFound();
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

    public static async Task<Results<Ok<ProgramProductViewModel>, NotFound>> GetProgramProductByCode(
        [FromServices] GetProgramProductsByCodeUseCase<ProgramProductViewModel> useCase, 
        [FromHeader] string? programId,
        [FromRoute] string productCode)
    {
        if (programId == null || !int.TryParse(programId, out int program))
        {
            return TypedResults.NotFound();
        }

        var product = await useCase.ExecuteAsync(program, productCode);

        if (product != null)
        {
            return TypedResults.Ok(product);
        }

        return TypedResults.NotFound();
    }

    public static async Task<Results<Ok<string>, BadRequest<ApiErrorResponse>>> AddProgramProduct(
       [FromServices] AddProductToProgramUseCase<AddProgramProductRequestDto> useCase,
       [FromServices] IValidator<AddProgramProductRequestDto> validator,
       [FromBody] AddProgramProductRequestDto product
       )
    {
        if(product == null)
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
}
