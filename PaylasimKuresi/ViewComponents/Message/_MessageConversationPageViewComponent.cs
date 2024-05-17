using AutoMapper;
using Business.PaylasimKuresi.Interfaces.DmServices;
using Business.PaylasimKuresi.Interfaces.UserServices;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.UserDTOs;
using Models.Errors;

namespace PaylasimKuresi.ViewComponents.Message;

public class _MessageConversationPageViewComponent : ViewComponent
{
    private readonly IDmService _dmService;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public _MessageConversationPageViewComponent(IDmService dmService, IUserService userService, IMapper mapper)
    {
        _dmService = dmService;
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<IViewComponentResult> InvokeAsync(Guid conversationId)
    {
        var user = await _userService.RetrieveUserByPrincipalAsync(UserClaimsPrincipal);
        if (user == null)
            throw SessionError.SessionTimeExpired;

        if (conversationId == Guid.Empty)
            return View();

        var chosenDm = await _dmService.GetAsync(dm => dm.ID == conversationId);
        if (chosenDm == null)
            return View();

        var dmList = await _dmService.GetListAsync(dm => (dm.ReceiverID == chosenDm.ReceiverID
        && dm.SenderID == chosenDm.SenderID) || (dm.ReceiverID == chosenDm.SenderID && dm.SenderID == chosenDm.ReceiverID));

        ViewBag.user = user;
        ViewBag.receiverUser = chosenDm.ReceiverID == user.Id ?
            _mapper.Map<GetUserDto>(chosenDm.Sender) : _mapper.Map<GetUserDto>(chosenDm.Receiver);
        return View(dmList);
    }
}
