using System.Text;
using System.Text.Json;
using Business.PaylasimKuresi.Interfaces.CommentLikeServices;
using Business.PaylasimKuresi.Interfaces.CommentServices;
using Business.PaylasimKuresi.Interfaces.CommunityServices;
using Business.PaylasimKuresi.Interfaces.PostLikeServices;
using Business.PaylasimKuresi.Interfaces.PostServices;
using Business.PaylasimKuresi.Interfaces.TextPostServices;
using Business.PaylasimKuresi.Interfaces.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.CommentDTOs;
using Models.DTOs.CommentLikeDTOs;
using Models.DTOs.CommunityDTOs;
using Models.DTOs.PostDTOs;
using Models.DTOs.PostLikeDTOs;
using Models.DTOs.TextPostDTOs;

namespace PaylasimKuresi.Controllers;

[Authorize]
[Route("[controller]")]
public class HomeController : Controller
{
    private readonly ITextPostService _textPostService;
    private readonly IUserService _userService;
    private readonly ICommentService _commentService;
    private readonly IPostLikeService _postLikeService;
    private readonly ICommentLikeService _commentLikeService;
    private readonly IPostService _postService;
    private readonly ICommunityService _communityService;


    public HomeController(ITextPostService textPostService,
        IUserService userService,
        ICommentService commentService,
        IPostLikeService postLikeService,
        ICommentLikeService commentLikeService,
        IPostService postService,
        ICommunityService communityService)
    {
        _textPostService = textPostService;
        _userService = userService;
        _commentService = commentService;
        _postLikeService = postLikeService;
        _commentLikeService = commentLikeService;
        _postService = postService;
        _communityService = communityService;
    }

    [Route("Index")]
    [HttpGet("{id}")]
    public async Task<IActionResult> Index(string id)
    {
        var user = await _userService.RetrieveUserByPrincipalAsync(User);
        if (user == null)
            return RedirectToAction("Index", "LogOut");

        List<GetPostDto> postDtoList;
        Guid communityId;

        if (id is null)
        {
            var community = await _communityService.GetAsync(c => c.Name == "Paylaşım Küresi");
            if (community is null)
                return View(new List<GetPostDto>());
            communityId = community.ID;
        }
        else
            communityId = Guid.Parse(id);

        postDtoList = await _postService.GetListAsync(p => p.CommunityID == communityId);
        postDtoList = [.. postDtoList.OrderByDescending(x => x.CreatedAt)];

        ViewBag.UserLikedPosts = user.LikedPosts;
        ViewBag.UserLikedComments = user.CommentLikes;
        return View(postDtoList);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost(CreateTextPostDto createTextPostDto)
    {
        var user = await _userService.RetrieveUserByPrincipalAsync(User);
        if (user == null)
            return RedirectToAction("Index", "LogOut");

        GetCommunityDto? community;
        if (createTextPostDto.CommunityId == Guid.Empty)
        {
            community = await _communityService.GetAsync(c => c.Name == "Paylaşım Küresi");
            if (community is null)
                return RedirectToAction("Index");
            createTextPostDto.CommunityId = community.ID;
        }


        community = await _communityService.GetAsync(c => c.ID == createTextPostDto.CommunityId);
        if (community is null)
            return RedirectToAction("Index");
        createTextPostDto.UserID = user.Id;
        createTextPostDto.Status = "Published";

        using (var client = new HttpClient())
        {
            var url = "http://127.0.0.1:5000/post_control";
            var json = $"{{\"post\": \"{createTextPostDto.Content}\", \"communityName\": \"{community.Name}\", \"communityDescription\": \"{community.Description}\"}}";
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);

                // Parse JSON response
                using (JsonDocument doc = JsonDocument.Parse(responseBody))
                {
                    JsonElement root = doc.RootElement;

                    bool isResultTrue = false;
                    if (root.TryGetProperty("result", out JsonElement resultElement) && resultElement.ValueKind == JsonValueKind.String)
                    {
                        isResultTrue = resultElement.GetString()?.Trim() == "1";
                    }

                    if (isResultTrue)
                    {
                        var textPost = await _textPostService.CreateAsync(createTextPostDto);
                        return RedirectToAction("Index", new { id = createTextPostDto.CommunityId });
                    }
                    Console.WriteLine($"Result is: {isResultTrue}");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }
        }

        return RedirectToAction("Index");
    }

    [Route("Home/SendComment")]
    [HttpPost]
    public async Task<IActionResult> SendComment(CreateCommentDto createCommentDto)
    {
        var user = await _userService.RetrieveUserByPrincipalAsync(User);
        if (user == null)
            return RedirectToAction("Index", "LogOut");
        createCommentDto.SentAt = DateTime.Now;
        createCommentDto.UserID = user.Id;

        if (ModelState.IsValid)
        {
            var result = await _commentService.CreateAsync(createCommentDto);
            var resultPost = await _postService.GetAsync(c => c.ID == result.PostID);
            if (resultPost is null)
                return RedirectToAction("Index");
            return RedirectToAction("Index", new { id = resultPost.CommunityID });
        }
        return RedirectToAction("Index");
    }

    [Route("LikePost")]
    [HttpPost]
    public async Task<IActionResult> LikePost([FromBody] CreatePostLikeDto createPostLikeDto)
    {
        var user = await _userService.RetrieveUserByPrincipalAsync(User);
        if (user == null)
            return RedirectToAction("Index", "LogOut");
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
        if (user == null)
            return RedirectToAction("Index", "LogOut");
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
