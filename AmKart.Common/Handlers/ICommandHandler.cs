using AmKart.Common.RabbitMq;
using AmKart.Common.Messages;
using System.Threading.Tasks;

namespace AmKart.Common.Handlers
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, ICorrelationContext context);
    }
}