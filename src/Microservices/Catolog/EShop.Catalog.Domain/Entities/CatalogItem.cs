using EShop.Domain.Core.Entities;
using System;

namespace EShop.Catalog.Domain.Entities
{
    public class CatalogItem : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureFileName { get; set; }
        public string PictureUri { get; set; }
        public Guid CatalogTypeId { get; set; }
        public virtual CatalogType CatalogType { get; set; }     
        public Guid CatalogBrandId { get; set; }
        public virtual CatalogBrand CatalogBrand { get; set; }
        public int AvailableStock { get; set; }
        public int RestockThreshold { get; set; }
        public int MaxStockThreshold { get; set; }
        public bool OnReorder { get; set; }
        public CatalogItem()
        {

        }
    }
}
