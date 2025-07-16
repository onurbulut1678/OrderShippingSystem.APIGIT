using Microsoft.AspNetCore.Mvc;

namespace OrderShippingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Bu sefer galiba çözdük");
        }
    }
}
