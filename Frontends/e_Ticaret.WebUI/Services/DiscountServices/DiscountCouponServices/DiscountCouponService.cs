using e_Ticaret.WebUIDtos.DiscountDtos.DiscountCouponDtos;

namespace e_Ticaret.WebUI.Services.DiscountServices.DiscountCouponServices;

public class DiscountCouponService : IDiscountCouponService
{
    private readonly HttpClient _httpClient;

    public DiscountCouponService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetDiscountCouponDetailByCode> GetDiscountCoupon(string code)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("discounts/getbycode/" + code);
        GetDiscountCouponDetailByCode? value = await responseMessage.Content.ReadFromJsonAsync<GetDiscountCouponDetailByCode>();
        return value;
    }
}
