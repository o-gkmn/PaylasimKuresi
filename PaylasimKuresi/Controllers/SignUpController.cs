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
        if (ModelState.IsValid)
        {
            var token = await _signService.SignUpAsync(createUserDto);
            return RedirectToAction("Index");
        }

        return View(createUserDto);
    }
}
