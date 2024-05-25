using e_Ticaret.WebUIDtos.CatalogDtos.SpecialOfferDtos;

namespace e_Ticaret.WebUI.Services.CatalogServices.SpecialOfferServices;

public class SpecialOfferService : ISpecialOfferService
{
    private readonly HttpClient _httpClient;

    public SpecialOfferService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
    {
        await _httpClient.PostAsJsonAsync<CreateSpecialOfferDto>("specialoffers", createSpecialOfferDto);
    }

    public async Task DeleteSpecialOfferAsync(string id)
    {
        await _httpClient.DeleteAsync("specialoffers?id=" + id);
    }

    public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("specialoffers");
        List<ResultSpecialOfferDto>? values = await responseMessage.Content.ReadFromJsonAsync<List<ResultSpecialOfferDto>>();
        return values;
    }

    public async Task<UpdateSpecialOfferDto> GetSpecialOfferForUpdateAsync(string id)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("specialoffers/" + id);
        UpdateSpecialOfferDto? value = await responseMessage.Content.ReadFromJsonAsync<UpdateSpecialOfferDto>();
        return value;
    }

    public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateSpecialOfferDto>("specialoffers", updateSpecialOfferDto);
    }
}
