using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.ViewComponents.ProductListViewComponents;

public class _ProductListPaginationComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() { return View(); }
}
