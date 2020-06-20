using EShop.Catalog.Domain.Dto;
using EShop.Common.Web;
using MediatR;

namespace EShop.Catalog.Domain.Query
{
    public class CatalogItemsQuery : IRequest<PaginatedResult<CatalogItemDto>>
    {
        public Paginated Paginated { get; set; }
        public string Ids { get; set; }
    }
}
