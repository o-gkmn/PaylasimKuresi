using AutoMapper;
using Business.PaylasimKuresi.Interfaces.PostServices;
using Business.PaylasimKuresi.Interfaces.UserServices;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.PostDTOs;

namespace PaylasimKuresi.ViewComponents.Home;

public class _PostFlowViewComponent : ViewComponent
{
    private readonly IPostService _postService;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public _PostFlowViewComponent(IPostService postService, IUserService userService, IMapper mapper)
    {
        _postService = postService;
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<IViewComponentResult> InvokeAsync(Guid userId, bool needLikedPosts = false)
    {
        List<GetPostDto> postDtoList = [];

        if (needLikedPosts == true)
        {
            var user = await _userService.GetAsync(u => u.Id == userId);
            foreach (var postLike in user.LikedPosts)
            {
                var mappedPost = _mapper.Map<GetPostDto>(postLike.Post);
                postDtoList.Add(mappedPost);
            }

            return View(postDtoList);
        }

        postDtoList = await _postService.GetListAsync(p => p.UserID == userId);
        postDtoList = [.. postDtoList.OrderByDescending(x => x.CreatedAt)];
        return View(postDtoList);
    }
}
