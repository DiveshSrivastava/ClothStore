using System;
using System.Text.RegularExpressions;
using AmKart.Common.Types;
using Microsoft.AspNetCore.Identity;

namespace AmKart.Services.Identity.Domain
{
    public class User : IIdentifiable
    {
        private static readonly Regex EmailRegex = new Regex(
            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
            RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);
            
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Role { get; private set; }
        public string PasswordHash { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        protected User()
        {
        }

        public User(Guid id, string email, string firstName, string lastName, string role)
        {
            if (!EmailRegex.IsMatch(email))
            {
                throw new DistributedEStoreException(Codes.InvalidEmail, 
                    $"Invalid email: '{email}'.");
            }
            if (!Domain.Role.IsValid(role))
            {
                throw new DistributedEStoreException(Codes.InvalidRole, 
                    $"Invalid role: '{role}'.");
            }        
            Id = id;
            Email = email.ToLowerInvariant();
            FirstName = firstName;
            LastName = lastName;
            Role = role.ToLowerInvariant();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password, IPasswordHasher<User> passwordHasher)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new DistributedEStoreException(Codes.InvalidPassword, 
                    "Password can not be empty.");
            }             
            PasswordHash = passwordHasher.HashPassword(this, password);
        }

        public bool ValidatePassword(string password, IPasswordHasher<User> passwordHasher)
            => passwordHasher.VerifyHashedPassword(this, PasswordHash, password) != PasswordVerificationResult.Failed;
    }
}