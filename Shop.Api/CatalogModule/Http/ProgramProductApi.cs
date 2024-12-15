using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Catalog.UseCases.Read;
using Shop.Application.Catalog;
using Shop.Application;
using Shop.Infrastructure.Catalog.ViewModel;
using FluentValidation;
using Shop.Api.Apis;
using Shop.Application.Catalog.UseCases.Write;
using Shop.Infrastructure.Catalog.Dtos;
using Shop.Application.Primitives;

namespace Shop.Api.CatalogModule.Http;

public static class ProgramProductApi
{
    public static RouteGroupBuilder MapProgramProductApiV1(this RouteGroupBuilder group)
    {
        var programProductApi = group.MapGroup("program-product")
            .WithTags("ProgramProduct");

        programProductApi.MapGet("/", GetProgramProducts);
        programProductApi.MapGet("/{productCode}", GetProgramProductByCode);
        programProductApi.MapPost("", AddProgramProduct);
        programProductApi.MapPost("product-reference", AddProductReference);

        return group;
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

        if (product.HasValue)
        {
            return TypedResults.Ok(product.Value);
        }

        return TypedResults.NotFound();
    }

    public static async Task<Results<Ok<string>, BadRequest<ApiErrorResponse>>> AddProgramProduct(
       [FromServices] AddProductToProgramUseCase<AddProgramProductRequestDto> useCase,
       [FromServices] IValidator<AddProgramProductRequestDto> validator,
       [FromBody] AddProgramProductRequestDto product
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

     public static async Task<Results<Ok<string>, BadRequest<ApiErrorResponse>>> AddProductReference(
     [FromServices] AddProductReferenceUseCase<AddProductReferenceRequestDto> useCase,
     [FromServices] IValidator<AddProductReferenceRequestDto> validator,
     [FromBody] AddProductReferenceRequestDto product
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
