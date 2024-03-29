using System;
using AmKart.Common.Messages;
using Newtonsoft.Json;

namespace AmKart.Services.Identity.Messages.Commands
{
    public class RevokeRefreshToken : ICommand
    {
        public Guid UserId { get; }
        public string Token { get; }

        [JsonConstructor]
        public RevokeRefreshToken(Guid userId, string token)
        {
            UserId = userId;
            Token = token;
        }
    }
}