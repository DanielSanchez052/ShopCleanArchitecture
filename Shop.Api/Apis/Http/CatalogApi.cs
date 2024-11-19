using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shop.Application;
using Shop.Application.Catalog;
using Shop.Application.Catalog.UseCases;
using Shop.Entities.Catalog;
using Shop.Infrastructure.Catalog.ViewModel;

namespace Shop.Api.Apis.Http;

public  static class CatalogApi
{
    public static IEndpointRouteBuilder MapCatalogApiV1(this IEndpointRouteBuilder app)
    {
        var catalogApi = app.MapGroup("catalog");

        catalogApi.MapGet("product/", GetProducts);
        catalogApi.MapGet("product/{id}", GetProductById);
        catalogApi.MapGet("program-product/", GetProgramProducts);
        catalogApi.MapGet("program-product/{productCode}", GetProgramProductByCode);
        catalogApi.MapGet("category", GetCategories);

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
}
