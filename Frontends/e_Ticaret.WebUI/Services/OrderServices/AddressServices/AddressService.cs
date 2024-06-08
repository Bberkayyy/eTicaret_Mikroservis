using e_Ticaret.WebUIDtos.OrderDtos.AddressDtos;

namespace e_Ticaret.WebUI.Services.OrderServices.AddressServices;

public class AddressService : IAddressService
{
    private readonly HttpClient _httpClient;

    public AddressService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateAddressAsync(CreateAddressDto createAddressDto)
    {
        await _httpClient.PostAsJsonAsync<CreateAddressDto>("addresses", createAddressDto);
    }

    public async Task DeleteAddressAsync(int id)
    {
        await _httpClient.DeleteAsync("addresses?id=" + id);
    }

    public async Task<UpdateAddressDto> GetAddressForUpdateAsync(int id)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("addresses/" + id);
        UpdateAddressDto? value = await responseMessage.Content.ReadFromJsonAsync<UpdateAddressDto>();
        return value;
    }

    public async Task<List<ResultAddressDto>> GetAllAddressAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("addresses");
        List<ResultAddressDto>? values = await responseMessage.Content.ReadFromJsonAsync<List<ResultAddressDto>>();
        return values;
    }

    public async Task UpdateAddressAsync(UpdateAddressDto updateAddressDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateAddressDto>("addresses", updateAddressDto);
    }
}
