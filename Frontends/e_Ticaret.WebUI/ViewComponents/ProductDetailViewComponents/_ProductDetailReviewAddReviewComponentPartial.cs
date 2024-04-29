using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.ViewComponents.ProductDetailViewComponents;

public class _ProductDetailReviewAddReviewComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke(string productId)
    {
        ViewBag.productId = productId;
        return View();
    }
}