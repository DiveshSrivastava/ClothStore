using AmKart.Common.Types;
using AmKart.Services.Product.Queries;
using System;
using System.Threading.Tasks;

namespace AmKart.Services.Products.Repositories
{
    public interface IProductsRepository
    {
        Task<DomainEntities.Product> GetAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task<bool> ExistsAsync(string name);
        Task<PagedResult<DomainEntities.Product>> BrowseAsync(BrowseProducts query);
        Task AddAsync(DomainEntities.Product product);
        Task UpdateAsync(DomainEntities.Product product);
        Task DeleteAsync(Guid id);
    }
}