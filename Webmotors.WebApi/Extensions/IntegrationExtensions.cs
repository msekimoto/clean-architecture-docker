using Microsoft.Extensions.DependencyInjection;

namespace Webmotors.WebApi.Extensions
{
    public static class IntegrationExtensions
    {
        public static IServiceCollection AddExternalIntegrations(this IServiceCollection services)
        {
            services.AddScoped<Application.Services.Interfaces.IMarcaVeiculoService, Application.Services.MarcaVeiculoService>();
            services.AddScoped<Application.Services.Interfaces.IModeloVeiculoService, Application.Services.ModeloVeiculoService>();
            services.AddScoped<Application.Services.Interfaces.IVersaoVeiculoService, Application.Services.VersaoVeiculoService>();

            return services;
        }
    }
}