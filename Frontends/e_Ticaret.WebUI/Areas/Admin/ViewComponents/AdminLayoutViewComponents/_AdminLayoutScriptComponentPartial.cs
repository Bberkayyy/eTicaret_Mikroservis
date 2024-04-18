using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents;

public class _AdminLayoutScriptComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() { return View(); }
}
