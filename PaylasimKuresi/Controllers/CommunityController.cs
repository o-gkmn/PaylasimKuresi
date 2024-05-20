using Business.PaylasimKuresi.Interfaces.CommunityServices;
using Business.PaylasimKuresi.Interfaces.CommunityUserServices;
using Business.PaylasimKuresi.Interfaces.RoleServices;
using Business.PaylasimKuresi.Interfaces.UserServices;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.CommunityDTOs;
using Models.DTOs.CommunityUserDTOs;

namespace PaylasimKuresi.Controllers;

[Route("[controller]")]
public class CommunityController : Controller
{
    private readonly ICommunityService _communityService;
    private readonly IUserService _userService;
    private readonly ICommunityUserService _communityUserService;

    public CommunityController(ICommunityService communityService, IUserService userService, ICommunityUserService communityUserService)
    {
        _communityService = communityService;
        _userService = userService;
        _communityUserService = communityUserService;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _userService.RetrieveUserByPrincipalAsync(User);
        if (user == null)
            return RedirectToAction("Index", "SignIn");

        var participatedCommunities = await _communityService.GetListAsync(
            c => c.CommunityUsers.Any(communityUser => communityUser.Member.Id == user.Id));
        participatedCommunities = participatedCommunities.OrderByDescending(c => c.CreatedAt).Take(4).ToList();

        var suggestedCommunities = await _communityService.GetListAsync(
            c => !c.CommunityUsers.Any(communityUser => communityUser.Member.Id == user.Id)
        );
        suggestedCommunities = suggestedCommunities.OrderByDescending(c => c.CreatedAt).Take(4).ToList();

        ViewBag.ParticipatedCommunities = participatedCommunities;
        ViewBag.SuggestedCommunities = suggestedCommunities;
        return View();
    }

    [Route("Create")]
    [HttpPost]
    public async Task<IActionResult> CreateCommunity([FromBody] CreateCommunityDto createCommunityDto)
    {
        var user = await _userService.RetrieveUserByPrincipalAsync(User);
        if (user == null)
            return RedirectToAction("Index", "SignIn");

        createCommunityDto.FounderID = user.Id;
        createCommunityDto.CreatedAt = DateTime.Now;

        if (ModelState.IsValid)
        {
            var result = await _communityService.CreateAsync(createCommunityDto);
            return Json(new { validationErrors = false });
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

    [Route("GetAllParticipatedCommunities")]
    [HttpGet]
    public async Task<IActionResult> GetAllParticipatedCommunitiesAsync()
    {
        var user = await _userService.RetrieveUserByPrincipalAsync(User);
        if (user == null)
            return RedirectToAction("Index", "SignIn");

        var participatedCommunities = await _communityService.GetListAsync(
            c => c.CommunityUsers.Any(communityUser => communityUser.Member.Id == user.Id));
        participatedCommunities = participatedCommunities.OrderByDescending(c => c.CreatedAt).ToList();

        if (participatedCommunities == null)
            return new JsonResult(new { });

        return new JsonResult(new { participatedCommunities });
    }

    [Route("GetAllSuggestedCommunities")]
    [HttpGet]
    public async Task<IActionResult> GetAllSuggestedCommunitiesAsync()
    {
        var user = await _userService.RetrieveUserByPrincipalAsync(User);
        if (user == null)
            return RedirectToAction("Index", "SignIn");

        var suggestedCommunities = await _communityService.GetListAsync(
            c => !c.CommunityUsers.Any(communityUser => communityUser.Member.Id == user.Id));
        suggestedCommunities = suggestedCommunities.OrderByDescending(c => c.CreatedAt).ToList();

        if (suggestedCommunities == null)
            return new JsonResult(new { });

        return new JsonResult(new { suggestedCommunities });
    }

    [Route("JoinCommunity")]
    [HttpPost]
    public async Task<IActionResult> JoinCommunityAsync([FromBody] CreateCommunityUserDto createCommunityUserDto)
    {
        var user = await _userService.RetrieveUserByPrincipalAsync(User);
        if (user == null)
            return RedirectToAction("Index", "SignIn");

        createCommunityUserDto.UserID = user.Id;
        createCommunityUserDto.JoinedAt = DateTime.UtcNow;

        if (ModelState.IsValid)
        {
            var result = await _communityUserService.CreateAsync(createCommunityUserDto);
            return new JsonResult(new { validationErrors = false });
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
}
