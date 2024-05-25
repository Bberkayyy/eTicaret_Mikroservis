using e_Ticaret.WebUIDtos.CatalogDtos.ProductDtos;

namespace e_Ticaret.WebUI.Services.CatalogServices.ProductServices;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateProductAsync(CreateProductDto createProductDto)
    {
        await _httpClient.PostAsJsonAsync<CreateProductDto>("products", createProductDto);
    }

    public async Task DeleteProductAsync(string id)
    {
        await _httpClient.DeleteAsync("products?id=" + id);
    }

    public async Task<List<ResultProductDto>> GetAllProductAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("products");
        List<ResultProductDto>? values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductDto>>();
        return values;
    }

    public async Task<List<ResultProductWithRelationshipsDto>> GetAllProductWithRelationshipsAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("products/withrelationships");
        List<ResultProductWithRelationshipsDto>? values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductWithRelationshipsDto>>();
        return values;
    }

    public async Task<List<ResultProductWithRelationshipsByCategoryIdDto>> GetAllProductWithRelationshipsByCategoryIdAsync(string categoryId)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("products/withrelationshipsbycategoryid?categoryId=" + categoryId);
        List<ResultProductWithRelationshipsByCategoryIdDto>? values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductWithRelationshipsByCategoryIdDto>>();
        return values;
    }

    public async Task<UpdateProductDto> GetProductForUpdateAsync(string id)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("products/" + id);
        UpdateProductDto? value = await responseMessage.Content.ReadFromJsonAsync<UpdateProductDto>();
        return value;
    }

    public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateProductDto>("products", updateProductDto);
    }

    public async Task<GetProductByIdDto> GetProductByIdAsync(string id)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("products/" + id);
        GetProductByIdDto? value = await responseMessage.Content.ReadFromJsonAsync<GetProductByIdDto>();
        return value;
    }
}
