using e_Ticaret.WebUIDtos.CargoDtos.CompanyDtos;

namespace e_Ticaret.WebUI.Services.CargoServices.CompanyServices;

public class CompanyService : ICompanyService
{
    private readonly HttpClient _httpClient;

    public CompanyService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateCompanyAsync(CreateCompanyDto createCompanyDto)
    {
        await _httpClient.PostAsJsonAsync<CreateCompanyDto>("companies", createCompanyDto);
    }

    public async Task DeleteCompanyAsync(int id)
    {
        await _httpClient.DeleteAsync("companies?id=" + id);
    }

    public async Task<UpdateCompanyDto> GetCompanyForUpdateAsync(int id)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("companies/" + id);
        UpdateCompanyDto? value = await responseMessage.Content.ReadFromJsonAsync<UpdateCompanyDto>();
        return value;
    }

    public async Task<List<ResultCompanyDto>> GetAllCompanyAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("companies");
        List<ResultCompanyDto>? values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCompanyDto>>();
        return values;
    }

    public async Task UpdateCompanyAsync(UpdateCompanyDto updateCompanyDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateCompanyDto>("companies", updateCompanyDto);
    }
}
