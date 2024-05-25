using AutoMapper;
using Business.PaylasimKuresi.Interfaces.FollowServices;
using Business.PaylasimKuresi.Interfaces.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.CommunityUserDTOs;
using Models.DTOs.FollowDTOs;
using Models.DTOs.PostLikeDTOs;
using Models.DTOs.UserDTOs;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace PaylasimKuresi.Controllers;

[Route("[controller]")]
[Authorize]
public class ProfileController : Controller
{
    private readonly IUserService _userService;
    private readonly IFollowService _followService;
    private readonly IMapper _mapper;

    public ProfileController(IUserService userService, IFollowService followService, IMapper mapper)
    {
        _userService = userService;
        _followService = followService;
        _mapper = mapper;
    }

    [HttpGet("Index/{id}")]
    public async Task<IActionResult> Index(string id)
    {
        var authUser = await _userService.RetrieveUserByPrincipalAsync(User);
        if (authUser == null)
            return RedirectToAction("Index", "LogOut");

        var uuid = Guid.Parse(id);
        var user = await _userService.GetAsync(u => u.Id == uuid);
        if (user == null)
            return RedirectToAction("Index", "Home");

        ViewBag.UserLikedPosts = user.LikedPosts;
        ViewBag.UserLikedComments = user.CommentLikes;
        ViewBag.AuthUser = authUser;
        return View(user);
    }

    [Route("FollowPerson")]
    [HttpPost]
    public async Task<IActionResult> FollowPersonAsync([FromBody] CreateFollowDto createFollowDto)
    {
        var user = await _userService.RetrieveUserByPrincipalAsync(User);
        if (user == null)
            return RedirectToAction("Index", "LogOut");

        createFollowDto.FollowingPersonID = user.Id;
        createFollowDto.FollowedAt = DateTime.UtcNow;

        if (ModelState.IsValid)
        {
            var existingFollow = user.Following.FirstOrDefault(f => f.FollowedPersonID == createFollowDto.FollowedPersonID);
            var mappedEntity = _mapper.Map<GetFollowDto>(existingFollow);
            var redirectUrl = Url.Action("Index", "Profile", new { id = createFollowDto.FollowedPersonID });

            if (existingFollow != null)
            {

                var followDto = await _followService.GetAsync(f => f.FollowedPersonID == createFollowDto.FollowedPersonID
                                                                   && f.FollowingPersonID == user.Id);
                if (followDto == null)
                    return new JsonResult(new { result = false });

                var deleteResult = await _followService.DeleteAsync(followDto);
                if (deleteResult)
                    return new JsonResult(new { result = true, href = redirectUrl });
            }

            var result = await _followService.CreateAsync(createFollowDto);
            if (result != null)
                return new JsonResult(new { result = true, href = redirectUrl });
        }

        return new JsonResult(new { result = false });
    }

    [Route("UploadProfilePicture")]
    [HttpPost]
    public async Task<IActionResult> UploadProfilePictureAsync([FromForm] IFormFile profilePicture)
    {
        var user = await _userService.RetrieveUserByPrincipalAsync(User);
        if (user == null)
            return RedirectToAction("Index", "LogOut");

        if (profilePicture == null || profilePicture.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                                    "wwwroot",
                                    "assets",
                                    "ProfilePictures",
                                    profilePicture.FileName);

        var dirName = Path.GetDirectoryName(filePath);

        if (dirName == null)
            return new JsonResult(new { result = false });

        Directory.CreateDirectory(dirName);

        using (var stream = profilePicture.OpenReadStream())
        {
            using (var image = Image.Load(stream))
            {
                image.Mutate(x => x.Resize(600, 600));

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.SaveAsJpegAsync(fileStream, new JpegEncoder
                    {
                        Quality = 75
                    });
                }
            }
        }

        string rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        string relativePath = filePath.Replace(rootPath, "").Replace("\\", "/");

        var updatedProfilePicDto = new UpdateProfilePictureUserDto
        {
            Id = user.Id,
            ProfilePictureUrl = relativePath,
        };

        var result = await _userService.UpdateProfilePicture(updatedProfilePicDto);
        if (result != null)
        {
            var redirectUrl = Url.Action("Index", "Profile", new { id = user.Id });
            return new JsonResult(new { result = true, href = redirectUrl });
        }

        return new JsonResult(new { result = false });
    }

    [HttpGet("Following/{userId}")]
    public async Task<IActionResult> GetFollowing(string userId)
    {
        var authUser = await _userService.RetrieveUserByPrincipalAsync(User);
        if (authUser == null)
            return RedirectToAction("Index", "LogOut");

        var uuid = Guid.Parse(userId);
        var user = await _userService.GetAsync(u => u.Id == uuid);
        if (user == null)
            return RedirectToAction("Index");

        var mappedFollowing = _mapper.Map<List<GetFollowDto>>(user.Following);
        ViewBag.Following = mappedFollowing;
        ViewBag.AuthUser = authUser;
        return View(user);
    }

    [HttpGet("Communities/{userId}")]
    public async Task<IActionResult> GetCommunities(string userId)
    {
        var authUser = await _userService.RetrieveUserByPrincipalAsync(User);
        if (authUser == null)
            return RedirectToAction("Index", "LogOut");

        var uuid = Guid.Parse(userId);
        var user = await _userService.GetAsync(u => u.Id == uuid);
        if (user == null)
            return RedirectToAction("Index");

        var mappedCommunityUsers = _mapper.Map<ICollection<GetCommunityUserDto>>(user.MemberCommunities);
        ViewBag.Communities = mappedCommunityUsers;
        ViewBag.AuthUser = authUser;
        return View(user);
    }

    [HttpGet("LikedPosts/{id}")]
    public async Task<IActionResult> GetLikedPosts(string id)
    {
        var authUser = await _userService.RetrieveUserByPrincipalAsync(User);
        if (authUser == null)
            return RedirectToAction("Index", "LogOut");

        var uuid = Guid.Parse(id);
        var user = await _userService.GetAsync(u => u.Id == uuid);
        if (user == null)
            return RedirectToAction("Index");

        var mappedLikedPosts = _mapper.Map<ICollection<GetPostLikeDto>>(user.LikedPosts);
        ViewBag.UserLikedPosts = mappedLikedPosts;
        ViewBag.AuthUser = authUser;
        return View(user);
    }
}
