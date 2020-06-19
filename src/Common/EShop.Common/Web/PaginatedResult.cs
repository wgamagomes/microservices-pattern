using EShop.Common.Web.Interfaces;
using System.Collections.Generic;

namespace EShop.Common.Web
{  
    public class PaginatedResult<TDto> where TDto : IDto
    {
        public int PageIndex { get; private set; }

        public int PageSize { get; private set; }

        public long Count { get; private set; }

        public IEnumerable<TDto> Data { get; private set; }

        public PaginatedResult(int pageIndex, int pageSize, long count, IEnumerable<TDto> data)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.Count = count;
            this.Data = data;
        }
    }
}
