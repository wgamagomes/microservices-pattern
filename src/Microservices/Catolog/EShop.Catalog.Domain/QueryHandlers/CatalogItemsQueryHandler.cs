using EShop.Catalog.Domain.Dto;
using EShop.Catalog.Domain.Query;
using EShop.Common.Web;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EShop.Catalog.Domain.QueryHandlers
{
    public class CatalogItemsQueryHandler : IRequestHandler<CatalogItemsPaginatedQuery, PaginatedResult<CatalogItemDto>>, IRequestHandler<CatalogItemsQuery, IEnumerable<CatalogItemDto>>
    {
        public async Task<PaginatedResult<CatalogItemDto>> Handle(CatalogItemsPaginatedQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => new PaginatedResult<CatalogItemDto>(0, 0, 0, null));
        }

        public async Task<IEnumerable<CatalogItemDto>> Handle(CatalogItemsQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => new List<CatalogItemDto>());
        }
    }
}
