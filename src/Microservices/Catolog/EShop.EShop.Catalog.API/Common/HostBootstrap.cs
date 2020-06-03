using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Catalog.API
{
    //TODO: Common
    public static class HostBootstrap
    {
        public static Task RunAsync<TStartup>() where TStartup : class
        {
            return Host.CreateDefaultBuilder()
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<TStartup>();
               }).Build().RunAsync();
        }
    }
}
