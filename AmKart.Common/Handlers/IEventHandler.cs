using AmKart.Common.RabbitMq;
using AmKart.Common.Messages;
using System.Threading.Tasks;

namespace AmKart.Common.Handlers
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event, ICorrelationContext context);
    }
}