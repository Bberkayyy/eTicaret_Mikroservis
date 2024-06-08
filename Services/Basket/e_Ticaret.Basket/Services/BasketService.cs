using e_Ticaret.Basket.Dtos;
using e_Ticaret.Basket.Settings;
using StackExchange.Redis;
using System.Text.Json;

namespace e_Ticaret.Basket.Services;

public class BasketService : IBasketService
{
    private readonly RedisService _redisService;

    public BasketService(RedisService redisService)
    {
        _redisService = redisService;
    }

    public async Task DeleteBasket(string userId)
    {
        await _redisService.GetDb().KeyDeleteAsync(userId);
    }

    public async Task<BasketTotalDto> GetBasket(string userId)
    {
        RedisValue existBasket = await _redisService.GetDb().StringGetAsync(userId);
        if (existBasket.IsNullOrEmpty)
        {
            BasketTotalDto newBasket = new()
            {
                UserId = userId,
                BasketItems = new List<BasketItemsDto>(),
                TotalPrice = 0,
                AfterDiscountTotalPrice = 0,
                DiscountAmount = 0,
            };
            return newBasket;
        }
        return JsonSerializer.Deserialize<BasketTotalDto>(existBasket);
    }

    public async Task SaveBasket(BasketTotalDto basketTotalDto)
    {
        if (basketTotalDto.BasketItems is null || !basketTotalDto.BasketItems.Any())
        {
            basketTotalDto.TotalPrice = 0;
            basketTotalDto.AfterDiscountTotalPrice = 0;
            basketTotalDto.DiscountAmount = 0;
        }
        else
        {
            basketTotalDto.TotalPrice = basketTotalDto.BasketItems.Sum(x => x.Quantity * x.UnitPrice);
            basketTotalDto.DiscountAmount = basketTotalDto.TotalPrice / 100 * basketTotalDto.DiscountCouponRate;
            basketTotalDto.AfterDiscountTotalPrice = basketTotalDto.TotalPrice - basketTotalDto.DiscountAmount;
        }
        await _redisService.GetDb().StringSetAsync(basketTotalDto.UserId, JsonSerializer.Serialize(basketTotalDto));
    }
}
