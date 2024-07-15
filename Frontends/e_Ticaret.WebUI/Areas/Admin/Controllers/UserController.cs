using e_Ticaret.WebUI.Services.Abstract;
using e_Ticaret.WebUIDtos.IdentityDtos.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/users")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [Route("index")]
    public async Task<IActionResult> Index()
    {
        ViewBag.v1 = "Anasayfa";
        ViewBag.v2 = "Kullanıcı İşlemleri";
        ViewBag.v3 = "Kullanıcı Listesi";
        List<ResultUserDto> values = await _userService.GetAllUsersAsync();
        return View(values);
    }
}
