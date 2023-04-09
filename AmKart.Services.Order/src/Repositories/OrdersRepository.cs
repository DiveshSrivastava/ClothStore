using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AmKart.Common.Mongo;

namespace AmKart.Services.Orders.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly IMongoRepository<DomainEntities.Order> _repository;

        public OrdersRepository(IMongoRepository<DomainEntities.Order> repository)
        {
            _repository = repository;
        }

        public async Task<DomainEntities.Order> GetAsync(Guid id)
            => await _repository.GetAsync(id);

        public async Task AddAsync(DomainEntities.Order order)
            => await _repository.AddAsync(order);

        public async Task UpdateAsync(DomainEntities.Order order)
            => await _repository.UpdateAsync(order);

        public async Task DeleteAsync(Guid id)
            => await _repository.DeleteAsync(id);

        public async Task<IEnumerable<DomainEntities.Order>> GetAllAsync()
            => await _repository.GetAllAsync();
    }
}