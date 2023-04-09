using System.Threading.Tasks;
using AmKart.Common.Types;

namespace AmKart.Common.Handlers
{
    public interface IQueryHandler<TQuery,TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}