using Business.PaylasimKuresi.Interfaces.DmServices;
using Business.PaylasimKuresi.Interfaces.UserServices;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.DmDTOs;

namespace PaylasimKuresi.Controllers;

[Route("[controller]")]
public class MessageController : Controller
{
    private readonly IUserService _userService;
    private readonly IDmService _dmService;

    public MessageController(IDmService dmService, IUserService userService)
    {
        _dmService = dmService;
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [Route("CreateNewConversation")]
    [HttpPost]
    public async Task<IActionResult> CreateNewConversation([FromBody] CreateDmDto createDmDto)
    {
        var user = await _userService.RetrieveUserByPrincipalAsync(User);
        //TODO: BURAYA KULLANICI OTURUMU SONLANDIRMA KODLARI GELECEK
        if (user == null)
            return RedirectToAction("Index", "SignIn");

        var receiverUser = await _userService.GetAsync(u => u.UserName == createDmDto.ReceiverUserName);
        if (receiverUser == null)
            return Json(new { validationErrors = true, errorMessage = "Böyle bir kullanıcı bulunamadı." });

        createDmDto.SenderID = user.Id;
        createDmDto.ReceiverID = receiverUser.Id;
        createDmDto.Status = "Send";
        createDmDto.SentAt = DateTime.Now;

        if (ModelState.IsValid)
        {
            var result = await _dmService.CreateAsync(createDmDto);
            return RedirectToAction("Index", "Message");
        }
        else
        {
            foreach (var entry in ModelState)
            {
                var key = entry.Key;
                var errors = entry.Value.Errors;
                foreach (var error in errors)
                {
                    string errorMsg = error.ErrorMessage;
                    return Json(new { validationErrors = true, errorMessage = errorMsg });
                }
            }
        }

        return RedirectToAction("Index");
    }

    [Route("UpdateConversationSection")]
    [HttpGet]
    public IActionResult UpdateConversationSection(Guid conversationId)
    {
        return ViewComponent("_MessageConversationPage", new { conversationId });
    }

    [Route("SendMessage")]
    [HttpPost]
    public async Task<IActionResult> SendMessage([FromBody] CreateDmDto createDmDto)
    {
        var user = await _userService.RetrieveUserByPrincipalAsync(User);
        if (user == null)
            return RedirectToAction("Index", "SignIn");

        createDmDto.SenderID = user.Id;
        createDmDto.Status = "Send";
        createDmDto.SentAt = DateTime.Now;

        if (ModelState.IsValid)
        {
            var result = await _dmService.CreateAsync(createDmDto);
            return new JsonResult(new { result });
        }
        return View();
    }
}
