﻿using e_Ticaret.WebUIDtos.CatalogDtos.ContactDtos;

namespace e_Ticaret.WebUI.Services.CatalogServices.ContactServices;

public class ContactService : IContactService
{
    private readonly HttpClient _httpClient;

    public ContactService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task ChangeIsReadToTrueAsync(string id)
    {
        await _httpClient.GetAsync("catalog/contacts/isreadtotrue?id=" + id);
    }

    public async Task CreateContactAsync(CreateContactDto createContactDto)
    {
        await _httpClient.PostAsJsonAsync<CreateContactDto>("catalog/contacts", createContactDto);
    }

    public async Task DeleteContactAsync(string id)
    {
        await _httpClient.DeleteAsync("catalog/contacts?id=" + id);
    }

    public async Task<List<ResultContactDto>> GetAllContactAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("catalog/contacts");
        List<ResultContactDto>? values = await responseMessage.Content.ReadFromJsonAsync<List<ResultContactDto>>();
        return values;
    }

    public async Task<ResultContactDto> GetContactForDetailAsync(string id)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("catalog/contacts/" + id);
        ResultContactDto? value = await responseMessage.Content.ReadFromJsonAsync<ResultContactDto>();
        return value;
    }
}
