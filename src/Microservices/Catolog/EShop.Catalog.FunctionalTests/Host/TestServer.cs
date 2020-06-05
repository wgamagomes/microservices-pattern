using EShop.Common.FluentBuilder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;

namespace EShop.Catalog.FunctionalTests.Host
{
    public class TestServerBuilder 
    {
        private IWebHostBuilder _hostBuilder;

        public  TestServer Build()
        {
           return new TestServer(_hostBuilder);

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

            return this;
        }
    }
}
