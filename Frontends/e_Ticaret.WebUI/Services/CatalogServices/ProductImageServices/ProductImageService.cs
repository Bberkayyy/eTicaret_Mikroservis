using e_Ticaret.WebUIDtos.CatalogDtos.ProductImageDtos;

namespace e_Ticaret.WebUI.Services.CatalogServices.ProductImageServices;

public class ProductImageService : IProductImageService
{
    private readonly HttpClient _httpClient;

    public ProductImageService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
    {
        await _httpClient.PostAsJsonAsync<CreateProductImageDto>("productimages", createProductImageDto);
    }

    public async Task DeleteProductImageAsync(string id)
    {
        await _httpClient.DeleteAsync("productimages?id=" + id);
    }

    public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("productimages");
        List<ResultProductImageDto>? values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductImageDto>>();
        return values;
    }

    public async Task<UpdateProductImageDto> GetProductImageForUpdateAsync(string id)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("productimages/" + id);
        UpdateProductImageDto? value = await responseMessage.Content.ReadFromJsonAsync<UpdateProductImageDto>();
        return value;
    }

    public async Task<ResultProductImageWithRelationshipsByProductIdDto> GetProductImageWithRelationshipsByProductIdAsync(string productId)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("productimages/getwithrelationshipsbyproductid?productId=" + productId);
        ResultProductImageWithRelationshipsByProductIdDto? value = await responseMessage.Content.ReadFromJsonAsync<ResultProductImageWithRelationshipsByProductIdDto>();
        return value;
    }

    public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateProductImageDto>("productimages", updateProductImageDto);
    }
}
