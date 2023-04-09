using System.Threading.Tasks;

namespace AmKart.Common.Mongo
{
    public interface IMongoDbSeeder
    {
        Task SeedAsync();
    }
}