using Business.Authentication.Interfaces.SignServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.UserDTOs;

namespace PaylasimKuresi.Controllers;

[Route("[controller]")]
public class SignInController : Controller
{
    private readonly ISignService _signService;
    private readonly ISignService _authenticationService;

    public SignInController(ISignService signService, ISignService authenticationService)
    {
        _signService = signService;
        _authenticationService = authenticationService;
    }

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
}
