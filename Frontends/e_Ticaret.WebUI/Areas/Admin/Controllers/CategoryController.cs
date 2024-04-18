using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
