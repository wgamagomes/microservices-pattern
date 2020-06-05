using EShop.Common.FluentBuilder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;

namespace EShop.Catalog.FunctionalTests.Host
{
    public class TestServerBuilder : Builder<TestServerBuilder, TestServer>
    {
        public TestServerBuilder CreateServer<TStartup>(string appsettings)
            where TStartup : class
        {
            var path = Assembly.GetAssembly(typeof(TStartup))
              .Location;

            var hostBuilder = new WebHostBuilder()
                .UseContentRoot(Path.GetDirectoryName(path))
                .ConfigureAppConfiguration(cb =>
                {
                    cb.AddJsonFile(appsettings, optional: false)
                    .AddEnvironmentVariables();
                }).UseStartup<TStartup>();

            _entity = new TestServer(hostBuilder);

            return this;
        }
    }
}
