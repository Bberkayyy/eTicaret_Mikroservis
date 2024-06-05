using e_Ticaret.WebUIDtos.BasketDtos;

namespace e_Ticaret.WebUI.Services.BasketServices;

public class BasketService : IBasketService
{
    private readonly HttpClient _httpClient;

    public BasketService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task AddBasketItem(BasketItemsDto basketItemsDto)
    {
        BasketTotalDto currentBasket = await GetBasket();
        if (currentBasket != null)
        {
            if (!currentBasket.BasketItems.Any(x => x.ProductId == basketItemsDto.ProductId))
                currentBasket.BasketItems.Add(basketItemsDto);
            else if (currentBasket.BasketItems.Any(x => x.ProductId == basketItemsDto.ProductId))
                currentBasket.BasketItems.Find(x => x.ProductId == basketItemsDto.ProductId).Quantity++;
        }
        await SaveBasket(currentBasket);
    }

    public Task DeleteBasket()
    {
        throw new NotImplementedException();
    }

    public async Task<BasketTotalDto> GetBasket()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("baskets");
        BasketTotalDto? values = await responseMessage.Content.ReadFromJsonAsync<BasketTotalDto>();
        return values;
    }

    public async Task RemoveBasketItem(string productId)
    {
        BasketTotalDto values = await GetBasket();
        BasketItemsDto? deletedItem = values.BasketItems.Find(x => x.ProductId == productId);
        bool result = values.BasketItems.Remove(deletedItem);
        if (result)
            await SaveBasket(values);
    }

    public async Task SaveBasket(BasketTotalDto basketTotalDto)
    {
        await _httpClient.PostAsJsonAsync<BasketTotalDto>("baskets", basketTotalDto);
    }
}
