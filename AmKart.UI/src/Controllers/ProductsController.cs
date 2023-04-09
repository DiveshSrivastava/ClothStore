using AmKart.Api.Services;
using Microsoft.AspNetCore.Mvc;
using AmKart.Common.Queries;
using System.Threading.Tasks;
using System;

namespace AmKart.UI.Controllers
{
    [ApiController]
    public class ProductsController : BaseController
    {
        private readonly IApiGatewayService apiGatewayService;

        public ProductsController(IApiGatewayService apiGatewayService)
        {
            this.apiGatewayService = apiGatewayService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BrowseProducts query)
            => Collection(await apiGatewayService.BrowseAsync(query));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Single(await apiGatewayService.GetProductById(id));
    }
}