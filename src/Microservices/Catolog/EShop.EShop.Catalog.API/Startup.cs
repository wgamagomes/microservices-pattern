using EShop.Catalog.Domain.Repositories;
using EShop.Catalog.Infrastructure.Data.Contexts;
using EShop.Catalog.Infrastructure.Data.Repositories;
using EShop.Common.Web.Extensions;
using EShop.Domain.Core.EventBus;
using EShop.Infrastructure.EventBusRabbitMQ;
using EShop.Infrastructure.EventBusRabbitMQ.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
                .AddEventBus(Configuration)
                .AddContext(Configuration)
                .AddRepositories();
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

        public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CatalogContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CatalogConnection"));
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICatalogItemRepository, CatalogItemRepository>();
            return services;
        }
    }
}
