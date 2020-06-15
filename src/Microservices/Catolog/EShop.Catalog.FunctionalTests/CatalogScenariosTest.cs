using Catalog.API;
using EShop.Catalog.FunctionalTests.Utils;
using EShop.Catalog.FunctionalTests.Extensions;
using EShop.Common.Web;
using System.Threading.Tasks;
using Xunit;
using System;

namespace EShop.Catalog.FunctionalTests
{
    public class CatalogScenariosTest
    {
        [Fact]
        public async Task Get_get_all_items_and_response_ok_status_code()
        {
            using (var server = TestServerBuilder.NewBuilder().CreateServer<Startup>().Build())
            {
                var response = await server.CreateClient().GetAsync(Get.Items());

                var items = await response.DeserializeCatalogAsync();

                response.EnsureSuccessStatusCode();
            }
        }
    }
}
