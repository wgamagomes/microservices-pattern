using EShop.Catalog.Infrastructure.Data.EF.interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.IO;
using System.Reflection;

namespace EShop.Catalog.FunctionalTests.Host
{
    public class TestServerBuilder
    {
        private IWebHostBuilder _hostBuilder;
        private TestServer _testServer;

        public TestServer Build()
        {
            return _testServer;

        }

        public TestServerBuilder CreateServer<TStartup>(string appsettings)
            where TStartup : class
        {
            var path = Assembly.GetAssembly(typeof(TStartup))
              .Location;

            _hostBuilder = new WebHostBuilder()
               .UseContentRoot(Path.GetDirectoryName(path))
               .ConfigureAppConfiguration(cb =>
               {
                   cb.AddJsonFile(appsettings, optional: false)
                   .AddEnvironmentVariables();
               }).UseStartup<TStartup>();

            _testServer = new TestServer(_hostBuilder);
            return this;
        }

        public TestServerBuilder WithMigrateDbContext<TContext, TOptions, TContextSeed>()
            where TContext : DbContext
            where TOptions : class, new()
            where TContextSeed : IContextSeed, new()
        {
            _testServer
                .Host
                .MigrateDbContext<TContext>((context, services) =>
                {
                    var env = services.GetService<IWebHostEnvironment>();
                    var settings = services.GetService<IOptions<TOptions>>();
                    new TContextSeed().SeedAsync(context, settings);
                });

            return this;
        }
    }
}