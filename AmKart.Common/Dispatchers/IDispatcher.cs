using System.Threading.Tasks;
using AmKart.Common.Types;
using AmKart.Common.Messages;

namespace AmKart.Common.Dispatchers
{
    public interface IDispatcher
    {
        Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}