using AmKart.Common.Handlers;
using AmKart.Services.Products.Dto;
using AmKart.Services.Products.Queries;
using AmKart.Services.Products.Repositories;
using System.Threading.Tasks;

namespace AmKart.Services.Products.Handlers
{
    public sealed class GetProductHandler : IQueryHandler<GetProduct, ProductDto>
    {
        private readonly IProductsRepository _productsRepository;

        public GetProductHandler(IProductsRepository productsRepository)
            => _productsRepository = productsRepository;

        public async Task<ProductDto> HandleAsync(GetProduct query)
        {
            var product = await _productsRepository.GetAsync(query.Id);

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageURLs = product.ImageURLs,
                Colors = product.Colors,
                Category = product.Category
            };
        }
    }
}