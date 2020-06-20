using EShop.Catalog.Domain.Dto;
using EShop.Catalog.Domain.Query;
using EShop.Common.Web;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EShop.Catalog.Domain.QueryHandlers
{
    public class CatalogItemsQueryHandler : IRequestHandler<CatalogItemsQuery, PaginatedResult<CatalogItemDto>>
    {
        public Task<PaginatedResult<CatalogItemDto>> Handle(CatalogItemsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
