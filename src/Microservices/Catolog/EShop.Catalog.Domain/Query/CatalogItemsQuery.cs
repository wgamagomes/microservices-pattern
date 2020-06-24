using EShop.Catalog.Domain.Dto;
using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace EShop.Catalog.Domain.Query
{
    public class CatalogItemsQuery : IRequest<IEnumerable<CatalogItemDto>>
    {
        public IEnumerable<string> Ids { get; set; }

        public bool IsValid()
        {
            var guids = Ids.Select(id => (Ok: int.TryParse(id, out int x), Value: x));

            return (!guids.All(nid => nid.Ok));           
        }
    }
}
