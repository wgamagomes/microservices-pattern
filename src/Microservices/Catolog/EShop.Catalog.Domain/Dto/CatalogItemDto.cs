using EShop.Catalog.Domain.Entities;
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
        public string PictureFileName { get; set; }
        public string PictureUri { get; set; }
        public Guid CatalogTypeId { get; set; }
        public Guid CatalogBrandId { get; set; }
        public int AvailableStock { get; set; }
        public int RestockThreshold { get; set; }
        public int MaxStockThreshold { get; set; }
        public bool OnReorder { get; set; }

        public CatalogItemDto(CatalogItem catalogItem)
        {
            Id = catalogItem.Id;
            Name = catalogItem.Name;
            Description = catalogItem.Description;
            Price = catalogItem.Price;
            PictureFileName = catalogItem.PictureFileName;
            PictureUri = catalogItem.PictureUri;
            CatalogTypeId = catalogItem.CatalogTypeId;
            CatalogBrandId = catalogItem.CatalogBrandId;
            AvailableStock = catalogItem.AvailableStock;
            RestockThreshold = catalogItem.RestockThreshold;
            MaxStockThreshold = catalogItem.MaxStockThreshold;
            OnReorder = catalogItem.OnReorder;
        }
    }
}
