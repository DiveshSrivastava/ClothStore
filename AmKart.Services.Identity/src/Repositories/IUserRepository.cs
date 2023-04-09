using System;
using System.Threading.Tasks;
using AmKart.Services.Identity.Domain;

namespace AmKart.Services.Identity.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
    }
}