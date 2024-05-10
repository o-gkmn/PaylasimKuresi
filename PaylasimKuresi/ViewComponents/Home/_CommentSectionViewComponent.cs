using Microsoft.AspNetCore.Mvc;
using Models.DTOs.PostDTOs;

namespace PaylasimKuresi.ViewComponents.Home;

public class _CommentSectionViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(GetPostDto getPostDto)
    {
        return View(getPostDto);
    }
}
