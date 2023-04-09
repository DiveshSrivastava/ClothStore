﻿using Microsoft.AspNetCore.Mvc;

namespace AmKart.Services.Product.Controllers
{
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index() => Ok("Order Service Home Page");
    }
}
