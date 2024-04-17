using e_Ticaret.Basket.Dtos;

namespace e_Ticaret.Basket.Services;

public interface IBasketService
{
    Task<BasketTotalDto> GetBasket(string userId);
    Task SaveBasket(BasketTotalDto basketTotalDto);
    Task DeleteBasket(string userId);
}
