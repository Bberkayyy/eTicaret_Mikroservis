
namespace e_Ticaret.WebUI.Services.StatisticServices.DiscountStatisticServices;

public class DiscountStatisticService : IDiscountStatisticService
{
    private readonly HttpClient _httpClient;

    public DiscountStatisticService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<int> GetDiscountCouponCount()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("statistics/getdiscountcopuncount");
        int value = await responseMessage.Content.ReadFromJsonAsync<int>();
        return value;
    }
}
