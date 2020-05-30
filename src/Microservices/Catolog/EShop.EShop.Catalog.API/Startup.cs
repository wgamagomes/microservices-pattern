using EShop.Domain.Core.EventBus;
using EShop.Infrastructure.EventBusRabbitMQ;
using EShop.Infrastructure.EventBusRabbitMQ.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            services.AddControllers();

            RegisterEventBus(services);
        }

        private void RegisterEventBus(IServiceCollection services)
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

                if (!string.IsNullOrEmpty(Configuration["EventBusRetryCount"]))
                {
                    retryCount = int.Parse(Configuration["EventBusRetryCount"]);
                }

                return new EventBusRabbitMQ(rabbitMQConnection, retryCount);
            });
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
        }
    }
}
