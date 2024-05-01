using Microsoft.AspNetCore.Mvc;

namespace PaylasimKuresi.Controllers;

[Route("[controller]")]
public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}
