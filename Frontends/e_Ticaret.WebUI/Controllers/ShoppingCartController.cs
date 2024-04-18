using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.Controllers;

public class ShoppingCartController : Controller
{
    public IActionResult ShoppingCart()
    {
        return View();
    }
}
