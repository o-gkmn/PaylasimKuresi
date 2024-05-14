using Business.PaylasimKuresi.Interfaces.DmServices;
using Business.PaylasimKuresi.Interfaces.UserServices;
using Microsoft.AspNetCore.Mvc;
using Models.Errors;

namespace PaylasimKuresi.ViewComponents.Message;

public class _MessageConversationPageViewComponent : ViewComponent
{
    private readonly IDmService _dmService;
    private readonly IUserService _userService;

    public _MessageConversationPageViewComponent(IDmService dmService, IUserService userService)
    {
        _dmService = dmService;
        _userService = userService;
    }

    public async Task<IViewComponentResult> InvokeAsync(Guid conversationId)
    {
        var user = await _userService.RetrieveUserByPrincipalAsync(UserClaimsPrincipal);
        if (user == null)
            throw SessionError.SessionTimeExpired;

        var chosenDm = await _dmService.GetAsync(dm => dm.ID == conversationId);
        if (chosenDm == null)
            return View();

        var dmList = await _dmService.GetListAsync(dm => (dm.ReceiverID == chosenDm.ReceiverID
        && dm.SenderID == chosenDm.SenderID) || (dm.ReceiverID == chosenDm.SenderID && dm.SenderID == chosenDm.ReceiverID));

        ViewBag.user = user;
        return View(dmList);
    }
}
