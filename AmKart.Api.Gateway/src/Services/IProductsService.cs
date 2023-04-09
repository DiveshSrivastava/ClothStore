using AmKart.Common.Types;
using AmKart.Common.Queries;
using RestEase;
using System;
using System.Threading.Tasks;
using AmKart.Common.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace AmKart.Api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IProductsService
    {
        [AllowAnyStatusCode]
        [Get("api/v1/products")]
        Task<PagedResult<Product>> BrowseAsync([Query] BrowseProducts query);

        [AllowAnyStatusCode]
        [Get("api/v1/products/{id}")]
        Task<Product> GetProductById([Path] Guid id);
    }
}
