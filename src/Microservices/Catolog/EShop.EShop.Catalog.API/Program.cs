using System.Threading.Tasks;

namespace Catalog.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
           await HostBootstrap.RunAsync<Startup>();
        }
    }
}
//https://www.facebook.com/groups/DomainDrivenDesignBrasil/?post_id=2005109059549702
//http://www.fabriciorissetto.com/blog/ddd-bounded-context/