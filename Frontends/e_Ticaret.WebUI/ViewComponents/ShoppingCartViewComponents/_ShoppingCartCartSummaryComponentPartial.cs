using e_Ticaret.WebUI.Services.BasketServices;
using e_Ticaret.WebUIDtos.BasketDtos;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.ViewComponents.ShoppingCartViewComponents;

public class _ShoppingCartCartSummaryComponentPartial : ViewComponent
{
    private readonly IBasketService _basketService;

    public _ShoppingCartCartSummaryComponentPartial(IBasketService basketService)
    {
        _basketService = basketService;
    }

    public async Task<IViewComponentResult> InvokeAsync(int couponRate)
    {
        BasketTotalDto value = await _basketService.GetBasket();
        ViewBag.CouponRate = couponRate;
        return View(value);
    }
}
