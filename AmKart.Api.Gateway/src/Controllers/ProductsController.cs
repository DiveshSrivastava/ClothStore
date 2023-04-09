using AmKart.Common.Messages.Products;
using AmKart.Common.Queries;
using AmKart.Api.Services;
using AmKart.Common.RabbitMq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using AmKart.Api.Auth;
using Microsoft.AspNetCore.Authorization;
using AmKart.Common.Models.Products;
using AmKart.Common.Types;
using AmKart.Common.Mvc;
using System.Collections.Generic;
using System.Net.Http;

namespace AmKart.Api.Gateway.Controllers
{
    [AdminAuth]
    public class ProductsController : BaseController
    {
        private readonly IProductsService _productsService;

        public ProductsController(IBusPublisher busPublisher, IProductsService productsService)
            : base(busPublisher)
        {
            _productsService = productsService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<PagedResult<Product>> Get([FromQuery] BrowseProducts query) {
            return await _productsService.BrowseAsync(query);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<Product> GetProductById(Guid id)
            => await _productsService.GetProductById(id);

        [HttpPost]
        public async Task<IActionResult> Post(CreateProduct command)
            => await SendAsync(command.BindId(c => c.Id),
                resourceId: command.Id, resource: "products");
    }
}