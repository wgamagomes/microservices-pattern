using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace EShop.Common.Web
{
    public static class HostBootstrap
    {
        public static Task RunHostAsync<TStartup>(string[] args)
             where TStartup : class
            => Host
                .CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<TStartup>())
                .Build()
                .RunAsync();
    }
}
