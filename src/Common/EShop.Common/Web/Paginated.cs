namespace EShop.Common.Web
{
    public class Paginated
    {
        public static string Get(int pageIndex, int pageSize)
        {
            return $"?pageIndex={pageIndex}&pageSize={pageSize}";
        }

        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 10;
    }
}
