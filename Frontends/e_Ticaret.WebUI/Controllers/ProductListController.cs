using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.Controllers;

public class ProductListController : Controller
{
    public IActionResult ProductList()
    {
        return View();
    }
    public IActionResult ProductDetail()
    {
        return View();
    }
}
