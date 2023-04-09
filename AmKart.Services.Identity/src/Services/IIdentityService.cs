using System;
using System.Threading.Tasks;
using AmKart.Common.Authentication;
using AmKart.Common.Models;
using AmKart.Services.Identity.Domain;

namespace AmKart.Services.Identity.Services
{
    public interface IIdentityService
    {
        Task<RegisterUserResponse> SignUpAsync(Guid id, string email, string firstName, string lastName, string password, string role = Role.User);
        Task<JsonWebToken> SignInAsync(string email, string password);
        Task ChangePasswordAsync(Guid userId, string currentPassword, string newPassword);         
    }
}