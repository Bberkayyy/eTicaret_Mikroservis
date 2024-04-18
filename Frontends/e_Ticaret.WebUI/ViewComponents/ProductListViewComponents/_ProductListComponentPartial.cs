using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.ViewComponents.ProductListViewComponents;

public class _ProductListComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() { return View(); }
}
