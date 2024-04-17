using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.ViewComponents.UILayoutViewComponents;

public class _UILayoutHeadComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() { return View(); }
}
