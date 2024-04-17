using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.ViewComponents.MainPageViewComponents;

public class _MainPageFeatureComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() { return View(); }
}
