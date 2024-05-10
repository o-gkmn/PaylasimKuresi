using Business.Authentication.Interfaces.SignServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.UserDTOs;

namespace PaylasimKuresi.Controllers;

[Route("[controller]")]
public class SignUpController : Controller
{
    private readonly ISignService _signService;

    public SignUpController(ISignService signService)
    {
        _signService = signService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(CreateUserDto createUserDto)
    {
        createUserDto.ProfilePictureUrl = "/assets/ProfilePictures/unknown_pp.jpg";
        if (ModelState.IsValid)
        {
            var result = await _signService.SignUpAsync(createUserDto);
            if (result)
            {
                var signInDto = new SignInUserDto()
                {
                    Email = createUserDto.Email,
                    Password = createUserDto.Password
                };
                var signInResult = await _signService.SignInAsync(signInDto);
                if (signInResult)
                    return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "SignIn");
        }

        return View(createUserDto);
    }
}
