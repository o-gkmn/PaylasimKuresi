using Microsoft.AspNetCore.Mvc;

namespace PaylasimKuresi.ViewComponents.Home;

public class _CommentSectionViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
