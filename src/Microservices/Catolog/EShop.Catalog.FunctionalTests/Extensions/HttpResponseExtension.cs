using EShop.Catalog.API.Model;
using EShop.Catalog.API.ViewModel;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace EShop.Catalog.FunctionalTests.Extensions
{
    public static class HttpResponseExtension
    {
        public static async Task<PaginatedViewModel<CatalogItem>> DeserializeCatalogAsync(this HttpResponseMessage response)
        {
            var items = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PaginatedViewModel<CatalogItem>>(items);
        }
    }
}
