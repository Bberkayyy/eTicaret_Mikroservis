using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.Areas.User.ViewComponents.UserLayoutViewComponents;

public class _UserLayoutHeadComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() { return View(); }
}
