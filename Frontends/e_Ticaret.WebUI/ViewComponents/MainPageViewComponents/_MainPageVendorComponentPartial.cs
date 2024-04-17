using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.ViewComponents.MainPageViewComponents;

public class _MainPageVendorComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() { return View(); }
}
