using Business.PaylasimKuresi.Interfaces.PostServices;
using DataAccess.Interfaces.PostRepositories;
using Microsoft.AspNetCore.Mvc;

namespace PaylasimKuresi.ViewComponents.Home;

public class _PostFlowViewComponent : ViewComponent
{
    private readonly IPostService _postService;

    public _PostFlowViewComponent(IPostService postService)
    {
        _postService = postService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var postDtoList = await _postService.GetListAsync();
        return View(postDtoList);
    }
}
