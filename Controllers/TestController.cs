using System;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryAPI.Controllers
{
    public class TestController : Controller
    {
        [HttpGet("api/user")]
        public IActionResult Get()
        {
            return Ok(new { name = "Shola" });
        }

    }
}
