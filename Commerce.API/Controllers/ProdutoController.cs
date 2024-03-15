using Microsoft.AspNetCore.Mvc;

namespace Commerce.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello world");
        }
    }
}
