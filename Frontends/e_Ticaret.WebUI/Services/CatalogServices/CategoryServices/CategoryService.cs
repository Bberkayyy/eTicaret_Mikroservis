using e_Ticaret.WebUIDtos.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;

namespace e_Ticaret.WebUI.Services.CatalogServices.CategoryServices;

public class CategoryService : ICategoryService
{
    private readonly HttpClient _httpClient;

    public CategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
    {
        await _httpClient.PostAsJsonAsync<CreateCategoryDto>("catalog/categories", createCategoryDto);
    }

    public async Task DeleteCategoryAsync(string id)
    {
        await _httpClient.DeleteAsync("catalog/categories?id=" + id);
    }

    public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("catalog/categories");
        string jsonData = await responseMessage.Content.ReadAsStringAsync();
        List<ResultCategoryDto>? values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
        return values;
    }

    public async Task<UpdateCategoryDto> GetCategoryForUpdateAsync(string id)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("catalog/categories/" + id);
        UpdateCategoryDto? value = await responseMessage.Content.ReadFromJsonAsync<UpdateCategoryDto>();
        return value;
    }

    public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateCategoryDto>("catalog/categories", updateCategoryDto);
    }

    public async Task<GetCategoryByIdDto> GetCategoryById(string id)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("catalog/categories/" + id);
        GetCategoryByIdDto? value = await responseMessage.Content.ReadFromJsonAsync<GetCategoryByIdDto>();
        return value;
    }
}
