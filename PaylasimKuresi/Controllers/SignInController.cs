using Business.Authentication.Interfaces.SignServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.UserDTOs;
using Models.Errors;

namespace PaylasimKuresi.Controllers;

[Route("[controller]")]
public class SignInController : Controller
{
    private readonly ISignService _signService;

    public SignInController(ISignService signService)
    {
        _signService = signService;
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
            try
            {
                var token = await _signService.SignInAsync(signInUserDto);
                Request.Headers.Append("Authorization", "Bearer " + token.AccessToken);
                Request.Headers.Append("Refresh-Token", token.RefreshToken);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                if (ex is Error error)
                {
                    if (error.Type == UserError.WrongPassword.Type)
                    {
                        ModelState.AddModelError(nameof(SignInUserDto.ErrorMessage), "Üzgünüz, şifreniz yanlıştı. Lütfen şifrenizi iki kez kontrol edin.");
                    }
                }
            }
        }
        return View(signInUserDto);
    }
}
