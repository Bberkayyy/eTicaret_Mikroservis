using e_Ticaret.WebUIDtos.CatalogDtos.ServiceDtos;

namespace e_Ticaret.WebUI.Services.CatalogServices.ServiceServices;

public class ServiceService : IServiceService
{
    private readonly HttpClient _httpClient;

    public ServiceService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateServiceAsync(CreateServiceDto createServiceDto)
    {
        await _httpClient.PostAsJsonAsync<CreateServiceDto>("services", createServiceDto);
    }

    public async Task DeleteServiceAsync(string id)
    {
        await _httpClient.DeleteAsync("services?id=" + id);
    }

    public async Task<List<ResultServiceDto>> GetAllServiceAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("services");
        List<ResultServiceDto>? values = await responseMessage.Content.ReadFromJsonAsync<List<ResultServiceDto>>();
        return values;
    }

    public async Task<UpdateServiceDto> GetServiceForUpdateAsync(string id)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("services/" + id);
        UpdateServiceDto? value = await responseMessage.Content.ReadFromJsonAsync<UpdateServiceDto>();
        return value;
    }

    public async Task UpdateServiceAsync(UpdateServiceDto updateServiceDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateServiceDto>("services", updateServiceDto);
    }
}
