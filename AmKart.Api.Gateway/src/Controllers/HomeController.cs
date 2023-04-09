using AmKart.Common.RabbitMq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmKart.Api.Gateway.Controllers
{
    [Route("")]
    public class HomeController : BaseController
    {
        public HomeController(IBusPublisher busPublisher) : base(busPublisher) { }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index() => Ok("AmKart Api-Gateway Home Page");
    }
}
