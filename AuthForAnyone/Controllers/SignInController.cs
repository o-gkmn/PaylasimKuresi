using AuthenticationServiceApi.Models.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationServiceApi.Controllers
{
    [Route("api/sign_in")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login(SignInUserDto signInUserDto)
        {
            return Ok();
        }

        [HttpPost("log_out")]
        public IActionResult Logout(SignInUserDto signInUserDto)
        {
            return BadRequest();
        }
    }
}
