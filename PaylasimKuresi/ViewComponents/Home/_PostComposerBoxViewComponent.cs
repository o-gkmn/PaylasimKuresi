using Microsoft.AspNetCore.Mvc;

namespace PaylasimKuresi.ViewComponents.Home;

public class _PostComposerBoxViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
