using EShop.Domain.Core.EventBus;
using EShop.Infrastructure.EventBusRabbitMQ;
using EShop.Infrastructure.EventBusRabbitMQ.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RabbitMQ.Client;

namespace Catalog.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddCustomControllers()
                .AddSwagger(Configuration)
                .AddEventBus(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCustomSwagger(Configuration);
        }
    }

    public static class StartupExtensionMethods
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "E-Shop HTTP API",
                    Version = "v1",
                    Description = "The Catalog Microservice HTTP API. This is a Data-Driven/CRUD microservice sample"
                });
            });

            return services;

        }

        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app, IConfiguration configuration)
        {
            var pathBase = configuration["PATH_BASE"];

            app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint($"{ (!string.IsNullOrEmpty(pathBase) ? pathBase : string.Empty) }/swagger/v1/swagger.json", "E-Shop HTTP API");

                });

            return app;
        }

        public static IServiceCollection AddCustomControllers(this IServiceCollection services)
        {
            services.AddControllers();

            return services;
        }

        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IRabbitMQConnection>(sp =>
            {
                var config = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .Build();

                var factory = new ConnectionFactory();

                config.GetSection("RabbitMqConnection").Bind(factory);

                return new RabbitMQConnection(factory, 5);
            });

            services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
            {
                var rabbitMQConnection = sp.GetRequiredService<IRabbitMQConnection>();

                var retryCount = 5;

                if (!string.IsNullOrEmpty(configuration["EventBusRetryCount"]))
                {
                    retryCount = int.Parse(configuration["EventBusRetryCount"]);
                }

                return new EventBusRabbitMQ(rabbitMQConnection, retryCount);
            });

            return services;
        }
    }
}
