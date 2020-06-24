using EShop.Catalog.Domain.Dto;
using EShop.Common.Web;
using MediatR;
using System.Collections.Generic;

namespace EShop.Catalog.Domain.Query
{
    public class CatalogItemsQuery : IRequest<IEnumerable<CatalogItemDto>>
    {
        public IEnumerable<string> Ids { get; set; }
    }
}
