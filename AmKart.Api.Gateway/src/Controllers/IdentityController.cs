using AmKart.Common.RabbitMq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AmKart.Api.Services;
using AmKart.Common.Commands.Identity;
using Microsoft.AspNetCore.Authorization;
using AmKart.Common.Authentication;
using AmKart.Common.Models;

namespace AmKart.Api.Gateway.Controllers
{
    public class IdentityController : BaseController
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IBusPublisher busPublisher, IIdentityService identityService)
            : base(busPublisher)
        {
            _identityService = identityService;
        }

        [AllowAnonymous]
        [HttpPost("sign-up")]
        public async Task<RegisterUserResponse> Post([FromBody] SignUpCommand command)
            => await _identityService.SignUp(command);

        [AllowAnonymous]
        [HttpPost("sign-in")]
        public async Task<JsonWebToken> Post([FromBody] SignInCommand command)
            => await _identityService.SignIn(command);
    }
}