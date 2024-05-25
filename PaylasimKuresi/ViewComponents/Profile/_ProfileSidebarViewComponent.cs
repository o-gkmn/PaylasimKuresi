using Microsoft.AspNetCore.Mvc;
using Models.DTOs.UserDTOs;

namespace PaylasimKuresi.ViewComponents.Profile;

public class _ProfileSidebarViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(GetUserDto user)
    {
        return View(user);
    }
}
