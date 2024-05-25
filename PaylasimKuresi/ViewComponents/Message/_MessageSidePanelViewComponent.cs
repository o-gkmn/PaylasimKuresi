using Business.PaylasimKuresi.Interfaces.DmServices;
using Business.PaylasimKuresi.Interfaces.UserServices;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Mvc;
using Models.Errors;

namespace PaylasimKuresi.ViewComponents.Message;

public class _MessageSidePanelViewComponent : ViewComponent
{
    private readonly IDmService _dmService;
    private readonly IUserService _userService;

    public _MessageSidePanelViewComponent(IDmService dmService, IUserService userService)
    {
        _dmService = dmService;
        _userService = userService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var user = await _userService.RetrieveUserByPrincipalAsync(UserClaimsPrincipal);
        if (user == null)
            throw SessionError.SessionTimeExpired;

        var dms = await _dmService.GetListAsync(dm => dm.SenderID == user.Id || dm.ReceiverID == user.Id);
        dms = dms.Where(m => m.SenderID == user.Id || m.ReceiverID == user.Id)
            .GroupBy(m => m.SenderID == user.Id ? m.ReceiverID : m.SenderID)
            .Select(g => g.OrderByDescending(m => m.SentAt).First())
            .ToList();

        ViewBag.user = user;
        return View(dms);
    }
}
