﻿using e_Ticaret.WebUIDtos.CatalogDtos.BrandDtos;

namespace e_Ticaret.WebUI.Services.CatalogServices.BrandServices;

public class BrandService : IBrandService
{
    private readonly HttpClient _httpClient;

    public BrandService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
    {
        await _httpClient.PostAsJsonAsync<CreateBrandDto>("catalog/brands", createBrandDto);
    }

    public async Task DeleteBrandAsync(string id)
    {
        await _httpClient.DeleteAsync("catalog/brands?id=" + id);
    }

    public async Task<List<ResultBrandDto>> GetAllBrandAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("catalog/brands");
        List<ResultBrandDto>? values = await responseMessage.Content.ReadFromJsonAsync<List<ResultBrandDto>>();
        return values;
    }

    public async Task<UpdateBrandDto> GetBrandForUpdateAsync(string id)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("catalog/brands/" + id);
        UpdateBrandDto? value = await responseMessage.Content.ReadFromJsonAsync<UpdateBrandDto>();
        return value;
    }

    public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateBrandDto>("catalog/brands", updateBrandDto);
    }
}
