using System.Threading.Tasks;
using Autofac;
using AmKart.Common.Handlers;
using AmKart.Common.Messages;
using AmKart.Common.RabbitMq;

namespace AmKart.Common.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;

        public CommandDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public async Task SendAsync<T>(T command) where T : ICommand
            => await _context.Resolve<ICommandHandler<T>>().HandleAsync(command, CorrelationContext.Empty);
    }
}