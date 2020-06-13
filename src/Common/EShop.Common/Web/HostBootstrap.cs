using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace EShop.Common.Web
{
    public static class HostBootstrap
    {
        public static Task RunHostAsync<TStartup>(string[] args)
             where TStartup : class
            => CreateHostBuilder<TStartup>(args)
                .Build()
                .RunAsync();

        public static IHostBuilder CreateHostBuilder<TStartup>(string[] args)
          where TStartup : class
        => Host
          .CreateDefaultBuilder(args)
          .ConfigureWebHostDefaults(webBuilder =>
                webBuilder
                    .UseConfiguration(ConfigureEnvironment().Build())
                    .UseStartup<TStartup>());

        private static IConfigurationBuilder ConfigureEnvironment()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables();

            return builder;
        }
    }
}
