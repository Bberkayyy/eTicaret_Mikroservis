using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.Controllers;

public class MainPageController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
