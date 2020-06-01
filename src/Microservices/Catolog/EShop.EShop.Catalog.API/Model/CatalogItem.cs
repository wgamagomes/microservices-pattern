using System;

namespace EShop.Catalog.API.Model
{
    public class CatalogItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
