using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Webmotors.Application;
using Webmotors.Application.Repositories;
using Webmotors.Domain;
using Webmotors.Infrastructure.Context;
using Webmotors.Infrastructure.Factories;
using Webmotors.Infrastructure.Repositories;
using Webmotors.Infrastructure.UoW;

namespace Webmotors.WebApi.Extensions
{
    public static class SQLServerInfrastructureExtensions
    {
        public static IServiceCollection AddSQLServerPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WebmotorsContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IEntityFactory, EntityFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAnuncioRepository, AnuncioRepository>();

            return services;
        }
    }
}