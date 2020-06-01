using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace EShop.Catalog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController
    {
        public CatalogController()
        {

        }

        [HttpGet]
        [Route("items")]

        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ItemsAsync([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0, string ids = null)
        {
            throw new NotImplementedException();

        }

    }
}
