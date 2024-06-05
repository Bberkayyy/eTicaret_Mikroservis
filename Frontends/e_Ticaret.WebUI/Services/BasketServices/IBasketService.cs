using e_Ticaret.WebUIDtos.BasketDtos;

namespace e_Ticaret.WebUI.Services.BasketServices;

public interface IBasketService
{
    Task<BasketTotalDto> GetBasket();
    Task SaveBasket(BasketTotalDto basketTotalDto);
    Task AddBasketItem(BasketItemsDto basketItemsDto);
    Task RemoveBasketItem(string productId);
    Task DeleteBasket();
}
