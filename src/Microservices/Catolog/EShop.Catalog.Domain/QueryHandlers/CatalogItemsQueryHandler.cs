using EShop.Catalog.Domain.Dto;
using EShop.Catalog.Domain.Query;
using EShop.Catalog.Domain.Repositories;
using EShop.Common.Web;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EShop.Catalog.Domain.QueryHandlers
{
    public class CatalogItemsQueryHandler : IRequestHandler<CatalogItemsPaginatedQuery, PaginatedResult<CatalogItemDto>>, IRequestHandler<CatalogItemsQuery, IEnumerable<CatalogItemDto>>
    {
        private readonly ICatalogItemRepository _catalogItemRepository;

        public CatalogItemsQueryHandler(ICatalogItemRepository catalogItemRepository)
        {
            _catalogItemRepository = catalogItemRepository;
        }
        public async Task<PaginatedResult<CatalogItemDto>> Handle(CatalogItemsPaginatedQuery request, CancellationToken cancellationToken)
        {
            var totalItems = await _catalogItemRepository.GetAll()
                .LongCountAsync();

            var itemsOnPage = await _catalogItemRepository.GetAll()
                .Select(c => new CatalogItemDto(c))
                .OrderBy(c => c.Name)
                .Skip(request.Paginated.PageSize * request.Paginated.PageIndex)
                .Take(request.Paginated.PageSize)
                .ToListAsync();

            return new PaginatedResult<CatalogItemDto>(request.Paginated.PageIndex, request.Paginated.PageSize, totalItems, itemsOnPage);
        }

        public async Task<IEnumerable<CatalogItemDto>> Handle(CatalogItemsQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => new List<CatalogItemDto>());
        }
    }
}
