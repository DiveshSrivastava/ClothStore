using AmKart.Common.Dispatchers;
using AmKart.Common.Types;
using AmKart.Services.Product.Queries;
using AmKart.Common.Mvc;
using AmKart.Services.Products.Dto;
using AmKart.Services.Products.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AmKart.Services.Product.Controllers
{
    public class ProductsController : BaseController
    {
        public ProductsController(IDispatcher dispatcher) : base(dispatcher) { }

        [HttpGet]
        public async Task<PagedResult<ProductDto>> Get([FromQuery] BrowseProducts query)
        {
            return await QueryAsync(query);
        }

        [HttpGet("{id}")]
        public async Task<ProductDto> GetAsync([FromRoute] GetProduct query)
            => await QueryAsync(query);
    }
}