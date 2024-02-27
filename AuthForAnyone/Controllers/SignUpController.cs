using AuthenticationServiceApi.Business.ActionFilters;
using AuthenticationServiceApi.Business.Services.Abstract;
using AuthenticationServiceApi.Models.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationServiceApi.Controllers
{
    [Route("api/sign_up")]
    [ApiController]
    [RequiredModelValidate]
    public class SignUpController : ControllerBase
    {
        private readonly ISignUpService _signUpService;

        public SignUpController(ISignUpService signUpService)
        {
            _signUpService = signUpService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(SignUpUserDto signUpUserDto)
        {
            await _signUpService.RegisterUserAsync(signUpUserDto);
            return Ok();
        }
    }
}
