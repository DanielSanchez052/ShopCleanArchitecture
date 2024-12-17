namespace Shop.Api.CatalogModule.Http;

public static class CatalogApi
{
    public static IEndpointRouteBuilder MapCatalogApiV1(this IEndpointRouteBuilder app)
    {
        var catalogApi = app.MapGroup("catalog")
            .WithTags("Catalog");

        catalogApi.MapProductApiV1();
        catalogApi.MapProgramProductApiV1();

        return app;
    }
}
