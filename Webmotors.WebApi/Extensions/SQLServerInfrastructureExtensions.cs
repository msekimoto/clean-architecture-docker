using System;
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
            var connectionString = string.Empty;

            connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                var hostname = Environment.GetEnvironmentVariable("SQLSERVER_HOST") ?? "localhost";
                var instance = Environment.GetEnvironmentVariable("SQLSERVER_INSTANCE") ?? "SQLEXPRESS";
                var catalog = Environment.GetEnvironmentVariable("SQLSERVER_CATALOG") ?? "teste_webmotors";
                var username = Environment.GetEnvironmentVariable("SQLSERVER_USERNAME") ?? "sa";
                var password = Environment.GetEnvironmentVariable("SQLSERVER_PASSWORD") ?? "p@ssw0rd";

                connectionString = $"Data Source={hostname},1433\\{instance};Initial Catalog={catalog};Persist Security Info=True;" +
                                       $"User ID={username};Password={password};Max Pool Size=1000;MultipleActiveResultSets=True;Trusted_Connection=false;";
            }

            services.AddDbContext<WebmotorsContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IEntityFactory, EntityFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAnuncioRepository, AnuncioRepository>();

            return services;
        }
    }
}