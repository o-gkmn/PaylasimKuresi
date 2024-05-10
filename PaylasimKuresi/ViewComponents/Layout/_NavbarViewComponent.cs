using Business.PaylasimKuresi.Interfaces.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace PaylasimKuresi.ViewComponents.Layout;

public class _NavbarViewComponent : ViewComponent
{
    private readonly IUserService _userService;

    public _NavbarViewComponent(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var user = await _userService.RetrieveUserByPrincipalAsync(UserClaimsPrincipal);
        return View(user);
    }
}
