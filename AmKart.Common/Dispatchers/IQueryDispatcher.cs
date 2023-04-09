using System.Threading.Tasks;
using AmKart.Common.Types;

namespace AmKart.Common.Dispatchers
{
    public interface IQueryDispatcher
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}