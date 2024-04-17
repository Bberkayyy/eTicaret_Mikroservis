using e_Ticaret.Basket.Dtos;
using e_Ticaret.Basket.LoginServices;
using e_Ticaret.Basket.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.Basket.Controllers;

[Route("api/baskets")]
[ApiController]
public class BasketsController : ControllerBase
{
    private readonly IBasketService _basketService;
    private readonly ILoginService _loginService;

    public BasketsController(IBasketService basketService, ILoginService loginService)
    {
        _basketService = basketService;
        _loginService = loginService;
    }
    [HttpGet]
    public async Task<IActionResult> GetMyBasket()
    {
        var user = User.Claims;
        BasketTotalDto values = await _basketService.GetBasket(_loginService.GetUserId);
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> SaveMyBasket(BasketTotalDto basketTotalDto)
    {
        basketTotalDto.UserId = _loginService.GetUserId;
        await _basketService.SaveBasket(basketTotalDto);
        return Ok("Sepetteki değişiklikler kaydedildi");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteMyBasket()
    {
        await _basketService.DeleteBasket(_loginService.GetUserId);
        return Ok("Sepet başarıyla silindi.");
    }
}
