using EShop.Common.Web.Interfaces;
using System;

namespace EShop.Catalog.Domain.Dto
{
    public class CatalogItemDto : IDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
