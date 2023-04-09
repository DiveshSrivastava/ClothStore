using System;
using System.Threading.Tasks;
using AmKart.Services.Identity.Domain;

namespace AmKart.Services.Identity.Repositories
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> GetAsync(string token);
        Task AddAsync(RefreshToken token);
        Task UpdateAsync(RefreshToken token);
    }
}