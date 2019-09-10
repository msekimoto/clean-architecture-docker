using Microsoft.Extensions.DependencyInjection;
using Webmotors.WebApi.Filters;

namespace Webmotors.WebApi.Extensions
{
    public static class BusinessExceptionExtensions
    {
        public static IServiceCollection AddBusinessExceptionFilter(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(BusinessExceptionFilter));
            });

            return services;
        }
    }
}
