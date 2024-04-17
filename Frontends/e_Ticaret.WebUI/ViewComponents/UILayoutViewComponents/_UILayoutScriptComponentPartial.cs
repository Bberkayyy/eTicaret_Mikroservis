using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.ViewComponents.UILayoutViewComponents;

public class _UILayoutScriptComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() { return View(); }
}
