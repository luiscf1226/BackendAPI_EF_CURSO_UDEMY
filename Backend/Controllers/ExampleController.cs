using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from ExampleController GET!");
        }

        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok($"Received value: {value}");
        }
    }
}