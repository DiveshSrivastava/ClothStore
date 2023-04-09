using System.Threading.Tasks;

namespace AmKart.Common
{
    public interface IInitializer
    {
        Task InitializeAsync();
    }
}