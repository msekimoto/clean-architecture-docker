using Microsoft.Extensions.DependencyInjection;

namespace Webmotors.WebApi.Extensions
{
    public static class UserInterfaceV1Extensions
    {
        public static IServiceCollection AddPresentersV1(this IServiceCollection services)
        {
            services.AddScoped<UseCases.V1.IncluirAnuncio.IncluirAnuncioPresenter>();
            services.AddScoped<Application.Boundaries.IncluirAnuncio.IOutput>(x => x.GetRequiredService<UseCases.V1.IncluirAnuncio.IncluirAnuncioPresenter>());

            services.AddScoped<UseCases.V1.AtualizarAnuncio.AtualizarAnuncioPresenter>();
            services.AddScoped<Application.Boundaries.AtualizarAnuncio.IOutput>(x => x.GetRequiredService<UseCases.V1.AtualizarAnuncio.AtualizarAnuncioPresenter>());

            services.AddScoped<UseCases.V1.RemoverAnuncio.RemoverAnuncioPresenter>();
            services.AddScoped<Application.Boundaries.RemoverAnuncio.IOutput>(x => x.GetRequiredService<UseCases.V1.RemoverAnuncio.RemoverAnuncioPresenter>());

            services.AddScoped<UseCases.V1.ConsultarAnuncio.ConsultarAnuncioPresenter>();
            services.AddScoped<Application.Boundaries.ConsultarAnuncio.IOutput>(x => x.GetRequiredService<UseCases.V1.ConsultarAnuncio.ConsultarAnuncioPresenter>());

            services.AddScoped<UseCases.V1.ListarMarcasVeiculo.ListarMarcasVeiculoPresenter>();
            services.AddScoped<Application.Boundaries.ListarMarcasVeiculo.IOutput>(x => x.GetRequiredService<UseCases.V1.ListarMarcasVeiculo.ListarMarcasVeiculoPresenter>());

            services.AddScoped<UseCases.V1.ListarModelosVeiculo.ListarModelosVeiculoPresenter>();
            services.AddScoped<Application.Boundaries.ListarModelosVeiculo.IOutput>(x => x.GetRequiredService<UseCases.V1.ListarModelosVeiculo.ListarModelosVeiculoPresenter>());

            services.AddScoped<UseCases.V1.ListarVersoesVeiculo.ListarVersoesVeiculoPresenter>();
            services.AddScoped<Application.Boundaries.ListarVersoesVeiculo.IOutput>(x => x.GetRequiredService<UseCases.V1.ListarVersoesVeiculo.ListarVersoesVeiculoPresenter>());

            return services;
        }
    }
}