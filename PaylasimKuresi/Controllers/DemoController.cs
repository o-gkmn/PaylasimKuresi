using AuthForAnyone.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AuthForAnyone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(UserAuthenticationFilter))]
    public class DemoController : ControllerBase
    {
        [HttpGet]
        public IActionResult TokenTest()
        {
            return Ok("Test Başarılı");
        }
    }
}
