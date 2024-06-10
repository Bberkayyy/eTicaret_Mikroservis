using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.Areas.User.Controllers;

[Area("User")]
public class ProfileController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
