using e_Ticaret.WebUI.Models;
using e_Ticaret.WebUI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        UserDetailViewModel value = await _userService.GetUserInfo();
        return View(value);
    }
}
