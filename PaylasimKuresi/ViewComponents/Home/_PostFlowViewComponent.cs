using Microsoft.AspNetCore.Mvc;

namespace PaylasimKuresi.ViewComponents.Home;

public class _PostFlowViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
