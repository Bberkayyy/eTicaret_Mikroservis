
namespace e_Ticaret.WebUI.Services.StatisticServices.CatalogStatisticServices;

public class CatalogStatisticService : ICatalogStatisticService
{
    private readonly HttpClient _httpClient;

    public CatalogStatisticService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<long> GetBrandCountAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("statistics/getbrandcount");
        long value = await responseMessage.Content.ReadFromJsonAsync<long>();
        return value;
    }

    public async Task<long> GetCategoryCountAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("statistics/getcategorycount");
        long value = await responseMessage.Content.ReadFromJsonAsync<long>();
        return value;
    }

    public async Task<long> GetProductCountAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("statistics/getproductcount");
        long value = await responseMessage.Content.ReadFromJsonAsync<long>();
        return value;
    }

    public async Task<string> GetProductNameOfMaxPriceProduct()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("statistics/getproductnameofmaxpriceproduct");
        string? value = await responseMessage.Content.ReadAsStringAsync();
        return value;
    }

    public async Task<string> GetProductNameOfMinPriceProduct()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("statistics/getproductnameofminpriceproduct");
        string? value = await responseMessage.Content.ReadAsStringAsync();
        return value;
    }
}
