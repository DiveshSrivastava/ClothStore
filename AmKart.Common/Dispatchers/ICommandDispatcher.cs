using System.Threading.Tasks;
using AmKart.Common.Messages;

namespace AmKart.Common.Dispatchers
{
    public interface ICommandDispatcher
    {
         Task SendAsync<T>(T command) where T : ICommand;
    }
}