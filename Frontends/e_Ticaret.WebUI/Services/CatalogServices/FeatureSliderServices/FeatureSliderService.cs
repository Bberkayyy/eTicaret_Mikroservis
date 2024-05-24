using e_Ticaret.WebUIDtos.CatalogDtos.FeatureSliderDtos;

namespace e_Ticaret.WebUI.Services.CatalogServices.FeatureSliderServices;

public class FeatureSliderService : IFeatureSliderService
{
    private readonly HttpClient _httpClient;

    public FeatureSliderService(HttpClient httpClient)
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

    public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
    {
        await _httpClient.PostAsJsonAsync<CreateFeatureSliderDto>("catalog/featuresliders", createFeatureSliderDto);
    }

    public async Task DeleteFeatureSliderAsync(string id)
    {
        await _httpClient.DeleteAsync("catalog/featuresliders?id=" + id);
    }

    public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("catalog/featuresliders");
        List<ResultFeatureSliderDto>? values = await responseMessage.Content.ReadFromJsonAsync<List<ResultFeatureSliderDto>>();
        return values;
    }

    public async Task<UpdateFeatureSliderDto> GetFeatureSliderForUpdateAsync(string id)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("catalog/featuresliders/" + id);
        UpdateFeatureSliderDto? value = await responseMessage.Content.ReadFromJsonAsync<UpdateFeatureSliderDto>();
        return value;
    }

    public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateFeatureSliderDto>("catalog/featuresliders", updateFeatureSliderDto);
    }
}
