using EShop.Catalog.Domain.Dto;
using EShop.Catalog.Domain.Entities;
using EShop.Catalog.Domain.Query;
using EShop.Catalog.Domain.Repositories;
using EShop.Common.Web;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EShop.Catalog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {
        private IMediator _mediator;
        private readonly CatalogSettings _settings;

        public CatalogController(IMediator mediator)
        {  
            _mediator = mediator;
        }

        [HttpPost]
        [Route("paginatedItems")]
        [ProducesResponseType(typeof(PaginatedResult<CatalogItemDto>), (int)HttpStatusCode.OK)]        
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ItemsAsync([FromBody]CatalogItemsPaginatedQuery catalogItemsQuery)
        {
            return Ok(await _mediator.Send(catalogItemsQuery));
        }

        [HttpPost]
        [Route("items")] 
        [ProducesResponseType(typeof(IEnumerable<CatalogItemDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ItemsAsync([FromBody]CatalogItemsQuery catalogItemsQuery)
        {
            return Ok(await _mediator.Send(catalogItemsQuery));
        }

        //[HttpGet]
        //[Route("items/type/all/brand/{catalogBrandId:int?}")]
        //[ProducesResponseType(typeof(PaginatedResult<CatalogItem>), (int)HttpStatusCode.OK)]
        //public async Task<ActionResult<PaginatedResult<CatalogItem>>> ItemsByBrandIdAsync(Guid? catalogBrandId, [FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        //{
        //    var root = _catalogItemRepository.GetAll();

        //    if (catalogBrandId.HasValue)
        //    {
        //        root = root.Where(ci => ci.CatalogBrandId == catalogBrandId);
        //    }

        //    var totalItems = await root
        //        .LongCountAsync();

        //    List<CatalogItem> itemsOnPage = await root
        //        .Skip(pageSize * pageIndex)
        //        .Take(pageSize)
        //        .ToListAsync();

        //    //itemsOnPage = ChangeUriPlaceholder(itemsOnPage);

        //    return new PaginatedResult<CatalogItem>(pageIndex, pageSize, totalItems, itemsOnPage);
        //}

        private List<CatalogItem> ChangeUriPlaceholder(List<CatalogItem> items)
        {
            var baseUri = _settings.PicBaseUrl;
            var azureStorageEnabled = _settings.AzureStorageEnabled;

            foreach (var item in items)
            {
                // item.FillProductUrl(baseUri, azureStorageEnabled: azureStorageEnabled);
            }

            return items;
        }

    }

    public class CatalogSettings
    {
        public string PicBaseUrl { get; set; }

        public string EventBusConnection { get; set; }

        public bool UseCustomizationData { get; set; }
        public bool AzureStorageEnabled { get; set; }
    }
}
