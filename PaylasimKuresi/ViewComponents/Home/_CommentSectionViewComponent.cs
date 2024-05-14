using Business.PaylasimKuresi.Interfaces.UserServices;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.PostDTOs;

namespace PaylasimKuresi.ViewComponents.Home;

public class _CommentSectionViewComponent : ViewComponent
{
    private readonly IUserService _userService;
    public _CommentSectionViewComponent(IUserService userService)
    {
        _userService = userService;
    }

    public IViewComponentResult Invoke(GetPostDto getPostDto)
    {
        return View(getPostDto);
    }
}
