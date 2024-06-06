using e_Ticaret.WebUI.Services.DiscountServices.DiscountCouponServices;
using e_Ticaret.WebUIDtos.DiscountDtos.DiscountCouponDtos;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.Controllers;

public class DiscountController : Controller
{
    private readonly IDiscountCouponService _discountCouponService;

    public DiscountController(IDiscountCouponService discountCouponService)
    {
        _discountCouponService = discountCouponService;
    }
    [HttpPost]
    public async Task<IActionResult> ConfirmCoupon(ConfirmCouponDto couponCode)
    {
        GetDiscountCouponDetailByCode value = await _discountCouponService.GetDiscountCoupon(couponCode.Code);
        int couponRate = value.Rate;
        return RedirectToAction("shoppingcart", "shoppingcart", new { couponRate = couponRate });
    }
}
