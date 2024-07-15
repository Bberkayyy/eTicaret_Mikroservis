using e_Ticaret.WebUIDtos.OrderDtos.OrderingDtos;

namespace e_Ticaret.WebUI.Services.OrderServices.OrderingServices;

public class OrderingService : IOrderingService
{
    private readonly HttpClient _httpClient;

    public OrderingService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ResultOrderingDto>> GetOrderingByUserIdAsync(string id)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("orderings/getbyuserid?id=" + id);
        List<ResultOrderingDto>? values = await responseMessage.Content.ReadFromJsonAsync<List<ResultOrderingDto>>();
        return values;
    }
}
