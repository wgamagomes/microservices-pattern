using EShop.Catalog.Domain.Dto;
using EShop.Common.Web;
using MediatR;

namespace EShop.Catalog.Domain.Query
{
    public class CatalogItemsPaginatedQuery : IRequest<PaginatedResult<CatalogItemDto>>
    {
        public Paginated Paginated { get; set; }
    }
}
