using Microsoft.AspNetCore.Mvc;

namespace PaylasimKuresi.ViewComponents.Message;

public class _NewConversationViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
