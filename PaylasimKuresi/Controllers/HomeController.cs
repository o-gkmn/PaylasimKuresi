using Business.PaylasimKuresi.Interfaces.CommentLikeServices;
using Business.PaylasimKuresi.Interfaces.CommentServices;
using Business.PaylasimKuresi.Interfaces.PostLikeServices;
using Business.PaylasimKuresi.Interfaces.TextPostServices;
using Business.PaylasimKuresi.Interfaces.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.CommentDTOs;
using Models.DTOs.CommentLikeDTOs;
using Models.DTOs.PostLikeDTOs;
using Models.DTOs.TextPostDTOs;

namespace PaylasimKuresi.Controllers;

[Route("[controller]")]
[Authorize]
public class HomeController : Controller
{
    private readonly ITextPostService _textPostService;
    private readonly IUserService _userService;
    private readonly ICommentService _commentService;
    private readonly IPostLikeService _postLikeService;
    private readonly ICommentLikeService _commentLikeService;

    public HomeController(ITextPostService textPostService,
        IUserService userService,
        ICommentService commentService,
        IPostLikeService postLikeService,
        ICommentLikeService commentLikeService)
    {
        _textPostService = textPostService;
        _userService = userService;
        _commentService = commentService;
        _postLikeService = postLikeService;
        _commentLikeService = commentLikeService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var user = await _userService.RetrieveUserByPrincipalAsync(User);
        if (user == null)
            return RedirectToAction("Index", "SignIn");

        ViewBag.UserLikedPosts = user.LikedPosts;
        ViewBag.UserLikedComments = user.CommentLikes;
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Index(CreateTextPostDto createTextPostDto)
    {
        var user = await _userService.RetrieveUserByPrincipalAsync(User);
        if (user == null)
            return RedirectToAction("Index", "SignIn");

        createTextPostDto.CommunityId = Guid.Empty;
        createTextPostDto.UserID = user.Id;
        createTextPostDto.Status = "Published";
        var textPost = await _textPostService.CreateAsync(createTextPostDto);
        return RedirectToAction("Index");
    }

    [Route("Home/SendComment")]
    [HttpPost]
    public async Task<IActionResult> SendComment(CreateCommentDto createCommentDto)
    {
        var user = await _userService.RetrieveUserByPrincipalAsync(User);
        //TODO: BURAYA KULLANICI OTURUMU SONLANDIRMA KODLARI GELECEK
        if (user == null)
            return RedirectToAction("Index", "SignIn");
        createCommentDto.SentAt = DateTime.Now;
        createCommentDto.UserID = user.Id;

        if (ModelState.IsValid)
        {
            var result = await _commentService.CreateAsync(createCommentDto);
        }
        return RedirectToAction("Index");
    }

    [Route("LikePost")]
    [HttpPost]
    public async Task<IActionResult> LikePost([FromBody] CreatePostLikeDto createPostLikeDto)
    {
        var user = await _userService.RetrieveUserByPrincipalAsync(User);
        //TODO: BURAYA KULLANICI OTURUMU SONLANDIRMA KODLARI GELECEK
        if (user == null)
            return RedirectToAction("Index", "SignIn");
        createPostLikeDto.LikedAt = DateTime.Now;
        createPostLikeDto.UserID = user.Id;

        if (ModelState.IsValid)
        {
            var result = await _postLikeService.CreateAsync(createPostLikeDto);

            if (result != null)
            {
                var postLikeList = await _postLikeService.GetListAsync(pl => pl.PostID == result.PostID);
                return Ok(new { newLikeCount = postLikeList.Count });
            }
        }

        return Ok();
    }

    [Route("LikeComment")]
    [HttpPost]
    public async Task<IActionResult> LikeComment([FromBody] CreateCommentLikeDto createCommentLikeDto)
    {
        var user = await _userService.RetrieveUserByPrincipalAsync(User);
        //TODO: BURAYA KULLANICI OTURUMU SONLANDIRMA KODLARI GELECEK
        if (user == null)
            return RedirectToAction("Index", "SignIn");
        createCommentLikeDto.LikedAt = DateTime.Now;
        createCommentLikeDto.UserID = user.Id;

        if (ModelState.IsValid)
        {
            var result = await _commentLikeService.CreateAsync(createCommentLikeDto);

            if (result != null)
            {
                var commentLikeList = await _commentLikeService.GetListAsync(cl => cl.CommentID == result.CommentID);
                return Ok(new { newLikeCount = commentLikeList.Count });
            }
        }

        return Ok();
    }
}
