using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminLayoutController : Controller
{
    public IActionResult _AdminLayout()
    {
        return View();
    }
}
