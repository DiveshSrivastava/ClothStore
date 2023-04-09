using AmKart.Common.Handlers;
using AmKart.Common.RabbitMq;
using System.Threading.Tasks;
using AmKart.Services.Orders.Repositories;
using AmKart.Common.Messages.Orders;
using System;

namespace AmKart.Services.Orders.Handlers
{
    public sealed class CreateOrderHandler : ICommandHandler<CreateOrder>
    {
        private readonly IOrdersRepository _ordersRepository;

        public CreateOrderHandler(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task HandleAsync(CreateOrder command, ICorrelationContext context)
        {
            await _ordersRepository.AddAsync(new DomainEntities.Order(
                    command.Id,
                    command.CustomerId,
                    MapToOraderItems(command.OrderItems))
                );
        }

        private DomainEntities.OrderItem[] MapToOraderItems(OrderItem[] requestOrderItems)
        {
            int itemsCount = requestOrderItems.Length;
            var orderItems = new DomainEntities.OrderItem[itemsCount];

            for (int i = 0; i < itemsCount; i++)
            {
                var currentItem = requestOrderItems[i];
                orderItems[i] = new DomainEntities.OrderItem(new Guid(),
                    currentItem.ProductId, currentItem.Quantity, currentItem.Size);
            }

            return orderItems;
        }
    }
}