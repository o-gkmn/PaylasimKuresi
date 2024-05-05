using Business.PaylasimKuresi.Interfaces.TextPostServices;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.TextPostDTOs;
using PaylasimKuresi.Filters;

namespace PaylasimKuresi.Controllers;

[Route("[controller]")]
[TypeFilter(typeof(UserAuthenticationFilter))]
public class HomeController : Controller
{
    private readonly ITextPostService _textPostService;

    public HomeController(ITextPostService textPostService)
    {
        _textPostService = textPostService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(CreateTextPostDto createTextPostDto)
    {
        createTextPostDto.CommunityId = Guid.Empty;
        createTextPostDto.UserID = Guid.Empty;
        createTextPostDto.Status = "Published";
        var textPost = await _textPostService.CreateAsync(createTextPostDto);
        return RedirectToAction("Index");
    }
}
