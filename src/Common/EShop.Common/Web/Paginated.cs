namespace EShop.Common.Web
{
    public class Paginated
    {
        public static string Get(int pageIndex, int pageSize)
        {
            return $"?pageIndex={pageIndex}&pageSize={pageSize}";
        }
    }
}
