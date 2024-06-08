using e_Ticaret.WebUI.Services.BasketServices;
using e_Ticaret.WebUI.Services.DiscountServices.DiscountCouponServices;
using e_Ticaret.WebUIDtos.BasketDtos;
using e_Ticaret.WebUIDtos.DiscountDtos.DiscountCouponDtos;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.Controllers;

public class DiscountController : Controller
{
    private readonly IDiscountCouponService _discountCouponService;
    private readonly IBasketService _basketService;

    public DiscountController(IDiscountCouponService discountCouponService, IBasketService basketService)
    {
        _discountCouponService = discountCouponService;
        _basketService = basketService;
    }
    [HttpPost]
    public async Task<IActionResult> ConfirmCoupon(ConfirmCouponDto couponCode)
    {
        GetDiscountCouponDetailByCode value = await _discountCouponService.GetDiscountCoupon(couponCode.Code);
        int couponRate = value.Rate;
        BasketTotalDto basket = await _basketService.GetBasket();
        basket.DiscountCouponRate = couponRate;
        basket.DiscountCouponCode = value.Code;
        await _basketService.SaveBasket(basket);
        return RedirectToAction("shoppingcart", "shoppingcart");
    }
}
