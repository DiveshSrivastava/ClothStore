using System.Threading.Tasks;
using Consul;

namespace AmKart.Common.Consul
{
    public interface IConsulServicesRegistry
    {
        Task<AgentService> GetAsync(string name);
    }
}