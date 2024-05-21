using Business.PaylasimKuresi.Interfaces.PostServices;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.PostDTOs;

namespace PaylasimKuresi.ViewComponents.Home;

public class _PostFlowViewComponent : ViewComponent
{
    private readonly IPostService _postService;

    public _PostFlowViewComponent(IPostService postService)
    {
        _postService = postService;
    }

    public async Task<IViewComponentResult> InvokeAsync(Guid? communityId)
    {
        List<GetPostDto> postDtoList;

        if (communityId == null)
            postDtoList = await _postService.GetListAsync();
        else
            postDtoList = await _postService.GetListAsync(p => p.CommunityID == communityId);

        postDtoList = [.. postDtoList.OrderByDescending(x => x.CreatedAt)];
        return View(postDtoList);
    }
}
