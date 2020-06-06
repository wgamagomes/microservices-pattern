using EShop.Common.Web;


namespace EShop.Catalog.FunctionalTests.Utils
{
    public static class Get
    {
        public static string Items(bool paginated = false, int pageIndex = 0, int pageSize = 10)
        {
            return paginated
                ? $"api/catalog/items{Paginated.Get(pageIndex, pageSize)}"
                : "api/catalog/items";
        }
    }
}
