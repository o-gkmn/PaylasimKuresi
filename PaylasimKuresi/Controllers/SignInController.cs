using Business.Authentication.Interfaces.SignServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.UserDTOs;

namespace PaylasimKuresi.Controllers;

[Route("[controller]")]
public class SignInController : Controller
{
    private readonly ISignService _authenticationService;

    public SignInController(ISignService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Index(SignInUserDto signInUserDto)
    {
        if (ModelState.IsValid)
        {
            var result = await _authenticationService.SignInAsync(signInUserDto);
            if (result)
                return RedirectToAction("Index", "Home");
            else
                ModelState.AddModelError(nameof(SignInUserDto.ErrorMessage), "Üzgünüz, şifreniz yanlıştı. Lütfen şifrenizi iki kez kontrol edin.");
        }
        return View(signInUserDto);
    }

    [Route("LogOut")]
    [HttpGet]
    public async Task<IActionResult> LogOut()
    {
        await _authenticationService.SignOutAsync();
        return RedirectToAction("Index", "SignIn");
    }

    [Route("AccessDenied")]
    [HttpGet]
    public IActionResult AccessDenied()
    {
        return View();
    }
}
