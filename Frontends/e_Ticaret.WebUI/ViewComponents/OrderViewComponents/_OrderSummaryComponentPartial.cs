using e_Ticaret.WebUI.Services.BasketServices;
using e_Ticaret.WebUIDtos.BasketDtos;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.ViewComponents.OrderViewComponents;

public class _OrderSummaryComponentPartial : ViewComponent
{
    private readonly IBasketService _basketService;

    public _OrderSummaryComponentPartial(IBasketService basketService)
    {
        _basketService = basketService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        BasketTotalDto basket = await _basketService.GetBasket();
        return View(basket);
    }
}
