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

    [HttpPost]
    public IActionResult Index(string a = "ads")
    {
        Console.WriteLine("Post çalıştı");
        return RedirectToAction("Index");
    }
}
