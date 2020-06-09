using EShop.Common.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace EShop.Common.Web.Extensions
{
    public static class StartupExtensionMethods
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(EnvironmentVariableValues.Version, new OpenApiInfo
                {
                    Title = $"E-Shop on containers - {EnvironmentVariableValues.MicroServiceName} http API",
                    Version = EnvironmentVariableValues.Version,
                    Description = $"The {EnvironmentVariableValues.MicroServiceName} http API. This is a Data-Driven/CRUD microservice sample"
                });
            });

            return services;
        }

        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint($"{ EnvironmentVariableValues.PathBase }/swagger/{EnvironmentVariableValues.Version}/swagger.json", EnvironmentVariableValues.MicroServiceName);
                });

            return app;
        }

        public static IServiceCollection AddCustomControllers(this IServiceCollection services)
        {
            services.AddControllers();

            return services;
        }
    }
}
