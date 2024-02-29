using AuthForAnyone.Filters;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.UserDTOs;

namespace AuthForAnyone.Controllers;

[Route("api/sign_up")]
[ApiController]
[ModelValidate]
public class SignUpController(ISignUpService signUpService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register(SignUpUserDto signUpUserDto)
    {
        var resultRegister = await signUpService.RegisterUserAsync(signUpUserDto);

        if (!resultRegister.IsSuccess)
        {
            return new BadRequestObjectResult(resultRegister.ToObject());
        }

        return Ok();
    }
}