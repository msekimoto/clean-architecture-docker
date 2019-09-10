using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Examples;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Webmotors.WebApi.Filters;

namespace Webmotors.WebApi.Extensions
{
    public static class VersionedSwaggerExtensions
    {
        public static IServiceCollection AddVersionedSwagger(this IServiceCollection services)
        {
            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddVersionedApiExplorer(o => o.GroupNameFormat = "'V'VVV");

            services.AddSwaggerGen(options =>
            {
                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var apiVersion in provider.ApiVersionDescriptions)
                    ConfigureVersionedDescription(options, apiVersion);

                var xmlCommentsPath = Assembly.GetExecutingAssembly().Location.Replace("dll", "xml");
                options.IncludeXmlComments(xmlCommentsPath);
                options.OperationFilter<ExamplesOperationFilter>();
                options.DocumentFilter<SwaggerDocumentFilter>();
            });

            return services;
        }

        private static void ConfigureVersionedDescription(SwaggerGenOptions options, ApiVersionDescription apiVersion)
        {
            var dictionairy = new Dictionary<string, string> { { "1.0", "Versão de demonstração" } };

            var apiVersionName = apiVersion.ApiVersion.ToString();
            options.SwaggerDoc(apiVersion.GroupName,
                new Info
                {
                        Title = "Teste Webmotors",
                        Contact = new Contact
                        {
                            Name = "@Marcelo Sekimoto",
                            Email = "msekimoto@gmail.com", Url = "https://www.linkedin.com/in/msekimoto/"
                        },
                        Version = apiVersionName,
                        Description = dictionairy[apiVersionName]
                });
        }

        public static IApplicationBuilder UseVersionedSwagger(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger(options =>
            {
                options.PreSerializeFilters.Add((swaggerDoc, httpRequest) =>
                {
                    if (httpRequest.Path.Value.Contains("/swagger"))
                        swaggerDoc.BasePath = httpRequest.Path.Value.Split("/").FirstOrDefault() ?? "";

                    if (httpRequest.Headers.TryGetValue("X-Forwarded-Prefix", out var xForwardedPrefix))
                        swaggerDoc.BasePath = xForwardedPrefix[0];
                });
            });

            app.UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
            });

            return app;
        }
    }
}