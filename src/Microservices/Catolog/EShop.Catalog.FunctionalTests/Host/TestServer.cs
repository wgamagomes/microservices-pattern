using EShop.Common.FluentBuilder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.IO;
using System.Reflection;

namespace EShop.Catalog.FunctionalTests.Host
{
    public  class TestServerBuilder
    {
        public  TestServer CreateServer<TStartup>()
            where TStartup: class
        {
            var path = Assembly.GetAssembly(typeof(TestServerBuilder))
              .Location;

            var hostBuilder = new WebHostBuilder()
                .UseContentRoot(Path.GetDirectoryName(path));
                //.ConfigureAppConfiguration(cb =>
                //{
                //    cb.AddJsonFile("Services/Catalog/appsettings.json", optional: false)
                //    .AddEnvironmentVariables();
                //}).UseStartup<TStartup>();

            var testServer = new TestServer(hostBuilder);


            return testServer;
        }
    }
}
