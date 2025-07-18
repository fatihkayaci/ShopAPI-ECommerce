// ShopAPI.API/Controllers/TestController.cs
using Microsoft.AspNetCore.Mvc;

namespace ShopAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { message = "API çalışıyor!", timestamp = DateTime.Now });
        }
    }
}