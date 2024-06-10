using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.Areas.User.Controllers;

[Area("User")]
public class UserLayoutController : Controller
{
    public IActionResult _UserLayout()
    {
        return View();
    }
}
