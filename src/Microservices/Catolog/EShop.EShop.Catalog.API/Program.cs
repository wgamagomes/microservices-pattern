using EShop.Common.Web;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Catalog.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        => await HostBootstrap.RunHostAsync<Startup>(args);

        public static IHostBuilder CreateHostBuilder(string[] args)
        => HostBootstrap.CreateHostBuilder<Startup>(args);
    }
}