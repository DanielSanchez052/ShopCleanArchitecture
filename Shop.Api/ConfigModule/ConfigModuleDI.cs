using Shop.Application.Interfaces;
using Shop.Infrastructure.Config.Repository;

namespace Shop.Api.ConfigModule;

public static class ConfigModuleDI
{
    public static IHostApplicationBuilder AddConfigModule(this IHostApplicationBuilder app)
    {
        //Repository
        app.Services.AddTransient<IRepository<Entities.Config.Program>, ProgramRepository>();

        //Presenters

        //Mappers

        //UseCases

        return app;
    }

}
