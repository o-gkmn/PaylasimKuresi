using Business.PaylasimKuresi.Interfaces.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace PaylasimKuresi.ViewComponents.Layout;

public class _SidebarViewComponent : ViewComponent
{
    private readonly IUserService _userService;

    public _SidebarViewComponent(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var user = await _userService.RetrieveUserByPrincipalAsync(UserClaimsPrincipal);
        if (user == null)
            return View();
        return View(user);
    }
}
