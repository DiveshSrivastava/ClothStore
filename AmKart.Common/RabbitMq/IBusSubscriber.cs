using System;
using AmKart.Common.Messages;
using AmKart.Common.Types;

namespace AmKart.Common.RabbitMq
{
    public interface IBusSubscriber
    {
        IBusSubscriber SubscribeCommand<TCommand>(string @namespace = null, string queueName = null,
            Func<TCommand, DistributedEStoreException, IRejectedEvent> onError = null)
            where TCommand : ICommand;

        IBusSubscriber SubscribeEvent<TEvent>(string @namespace = null, string queueName = null,
            Func<TEvent, DistributedEStoreException, IRejectedEvent> onError = null) 
            where TEvent : IEvent;
    }
}
