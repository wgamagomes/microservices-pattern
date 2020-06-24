using EShop.Catalog.Domain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EShop.Catalog.Domain.Query
{
    public class CatalogItemsQuery : IRequest<IEnumerable<CatalogItemDto>>
    {
        public IEnumerable<string> Ids { get; set; }

        public bool IsValid() => !Ids.All(id => IsGuid(id));

        private bool IsGuid(string candidate) => candidate != null
            && new Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", RegexOptions.Compiled)
                .IsMatch(candidate);
    }
}
