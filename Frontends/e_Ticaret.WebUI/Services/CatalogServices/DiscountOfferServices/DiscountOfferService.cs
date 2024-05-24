using e_Ticaret.WebUIDtos.CatalogDtos.DiscountOfferDtos;

namespace e_Ticaret.WebUI.Services.CatalogServices.DiscountOfferServices;

public class DiscountOfferService : IDiscountOfferService
{
    private readonly HttpClient _httpClient;

    public DiscountOfferService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task ChangeStatusToFalseAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task ChangeStatusToTrueAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task CreateDiscountOfferAsync(CreateDiscountOfferDto createDiscountOfferDto)
    {
        await _httpClient.PostAsJsonAsync<CreateDiscountOfferDto>("catalog/discountoffers", createDiscountOfferDto);
    }

    public async Task DeleteDiscountOfferAsync(string id)
    {
        await _httpClient.DeleteAsync("catalog/discountoffers?id=" + id);
    }

    public async Task<List<ResultDiscountOfferDto>> GetAllDiscountOfferAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("catalog/discountoffers");
        List<ResultDiscountOfferDto>? values = await responseMessage.Content.ReadFromJsonAsync<List<ResultDiscountOfferDto>>();
        return values;
    }

    public async Task<UpdateDiscountOfferDto> GetDiscountOfferForUpdateAsync(string id)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("catalog/discountoffers/" + id);
        UpdateDiscountOfferDto? value = await responseMessage.Content.ReadFromJsonAsync<UpdateDiscountOfferDto>();
        return value;
    }

    public async Task UpdateDiscountOfferAsync(UpdateDiscountOfferDto updateDiscountOfferDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateDiscountOfferDto>("catalog/discountoffers", updateDiscountOfferDto);
    }
}
