using AmKart.Common.Handlers;
using AmKart.Common.Types;
using AmKart.Services.Product.Queries;
using AmKart.Services.Products.Dto;
using AmKart.Services.Products.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace AmKart.Services.Products.Handlers
{
    public sealed class BrowseProductsHandler : IQueryHandler<BrowseProducts, PagedResult<ProductDto>>
    {
        private readonly IProductsRepository _productsRepository;

        public BrowseProductsHandler(IProductsRepository productsRepository)
            => _productsRepository = productsRepository;

        public async Task<PagedResult<ProductDto>> HandleAsync(BrowseProducts query)
        {
            var pagedResult = await _productsRepository.BrowseAsync(query);
            var products = pagedResult.Items.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Colors = p.Colors,
                ImageURLs = p.ImageURLs,
                Category = p.Category
            }).ToList();

            return PagedResult<ProductDto>.From(pagedResult, products);
        }
    }
}