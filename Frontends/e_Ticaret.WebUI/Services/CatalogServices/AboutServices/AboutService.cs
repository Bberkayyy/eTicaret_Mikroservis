using e_Ticaret.WebUIDtos.CatalogDtos.AboutDtos;

namespace e_Ticaret.WebUI.Services.CatalogServices.AboutServices;

public class AboutService : IAboutService
{
    private readonly HttpClient _httpClient;

    public AboutService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
    {
        await _httpClient.PostAsJsonAsync<CreateAboutDto>("catalog/abouts", createAboutDto);
    }

    public async Task DeleteAboutAsync(string id)
    {
        await _httpClient.DeleteAsync("catalog/abouts?id=" + id);
    }

    public async Task<UpdateAboutDto> GetAboutForUpdateAsync(string id)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("catalog/abouts/" + id);
        UpdateAboutDto? value = await responseMessage.Content.ReadFromJsonAsync<UpdateAboutDto>();
        return value;
    }

    public async Task<List<ResultAboutDto>> GetAllAboutAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("catalog/abouts");
        List<ResultAboutDto>? values = await responseMessage.Content.ReadFromJsonAsync<List<ResultAboutDto>>();
        return values;
    }

    public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateAboutDto>("catalog/abouts", updateAboutDto);
    }
}
