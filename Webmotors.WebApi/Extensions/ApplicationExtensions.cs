using Microsoft.Extensions.DependencyInjection;

namespace Webmotors.WebApi.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<Application.Boundaries.IncluirAnuncio.IUseCase, Application.UseCases.IncluirAnuncio>();
            services.AddScoped<Application.Boundaries.AtualizarAnuncio.IUseCase, Application.UseCases.AtualizarAnuncio>();
            services.AddScoped<Application.Boundaries.RemoverAnuncio.IUseCase, Application.UseCases.RemoverAnuncio>();
            services.AddScoped<Application.Boundaries.ConsultarAnuncio.IUseCase, Application.UseCases.ConsultarAnuncio>();
            services.AddScoped<Application.Boundaries.ListarMarcasVeiculo.IUseCase, Application.UseCases.ListarMarcasVeiculoUseCase>();
            services.AddScoped<Application.Boundaries.ListarModelosVeiculo.IUseCase, Application.UseCases.ListarModelosVeiculoUseCase>();
            services.AddScoped<Application.Boundaries.ListarVersoesVeiculo.IUseCase, Application.UseCases.ListarVersoesVeiculoUseCase>();

            return services;
        }
    }
}