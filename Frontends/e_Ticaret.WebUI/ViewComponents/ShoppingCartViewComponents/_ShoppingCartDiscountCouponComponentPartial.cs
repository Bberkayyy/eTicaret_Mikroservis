using e_Ticaret.WebUIDtos.DiscountDtos.DiscountCouponDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace e_Ticaret.WebUI.ViewComponents.ShoppingCartViewComponents;

public class _ShoppingCartDiscountCouponComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        ConfirmCouponDto couponModel = new();
        return View(couponModel);
    }
}
