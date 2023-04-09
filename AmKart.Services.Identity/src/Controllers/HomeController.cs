using Microsoft.AspNetCore.Mvc;

namespace AmKart.Services.Identity.Controllers
{
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("AmKart Identity Service");
    }
}