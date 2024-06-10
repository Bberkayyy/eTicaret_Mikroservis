using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.Areas.User.Controllers;

[Area("User")]
public class OrderController : Controller
{
    public IActionResult MyOrderList()
    {
        return View();
    }
}
