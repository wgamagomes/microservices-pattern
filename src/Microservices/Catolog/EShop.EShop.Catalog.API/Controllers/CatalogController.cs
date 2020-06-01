﻿using EShop.Catalog.API.Model;
using EShop.Catalog.API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;


namespace EShop.Catalog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController: ControllerBase
    {
        public CatalogController()
        {

        }

        [HttpGet]
        [Route("items")]
        [ProducesResponseType(typeof(PaginatedViewModel<CatalogItem>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IEnumerable<CatalogItem>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult ItemsAsync([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0, string ids = null)
        {

            if (!string.IsNullOrEmpty(ids))
            {
                var items =  GetItemsByIdsAsync(ids);

                if (!items.Any())
                {
                    return BadRequest("ids value invalid. Must be comma-separated list of numbers");
                }

                return Ok(items);
            }

            var totalItems = 1000;

            var itemsOnPage = new List<CatalogItem>();

            var model = new PaginatedViewModel<CatalogItem>(pageIndex, pageSize, totalItems, itemsOnPage);

            return Ok(model);
        }

        private List<CatalogItem> GetItemsByIdsAsync(string ids)
        {
            var numIds = ids.Split(',').Select(id => (Ok: Guid.TryParse(id, out Guid x), Value: x));

            if (!numIds.All(nid => nid.Ok))
            {
                return new List<CatalogItem>();
            }

            var idsToSelect = numIds
                .Select(id => id.Value);

            var items = new List<CatalogItem>();

            return items;
        }

    }
}
