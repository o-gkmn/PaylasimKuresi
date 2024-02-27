using AuthenticationServiceApi.Business.ActionFilters;
using AuthenticationServiceApi.Business.Services.Abstract;
using AuthenticationServiceApi.Models.Dtos.UserDtos;
using AuthForAnyone.Models.Errors;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationServiceApi.Controllers
{
    [Route("api/sign_up")]
    [ApiController]
    [ModelValidate]
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
            var resultRegister = await _signUpService.RegisterUserAsync(signUpUserDto);
            
            if(!resultRegister.IsSuccess)
            {
                return new BadRequestObjectResult(resultRegister.ToObject());
            }

            return Ok();
        }
    }
}
