using e_Ticaret.WebUIDtos.CatalogDtos.ProductDetailDtos;

namespace e_Ticaret.WebUI.Services.CatalogServices.ProductDetailServices;

public class ProductDetailService : IProductDetailService
{
    private readonly HttpClient _httpClient;

    public ProductDetailService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
    {
        await _httpClient.PostAsJsonAsync<CreateProductDetailDto>("productdetails", createProductDetailDto);
    }

    public async Task DeleteProductDetailAsync(string id)
    {
        await _httpClient.DeleteAsync("productdetails?id=" + id);
    }

    public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("productdetails");
        List<ResultProductDetailDto>? values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductDetailDto>>();
        return values;
    }

    public async Task<UpdateProductDetailDto> GetProductDetailForUpdateAsync(string id)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("productdetails/" + id);
        UpdateProductDetailDto? value = await responseMessage.Content.ReadFromJsonAsync<UpdateProductDetailDto>();
        return value;
    }

    public async Task<ResultProductDetailWithRelationshipsByProductIdDto> GetProductDetailWithRelationshipsByProductIdAsync(string productId)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("productdetails/getwithrelationshipsbyproductid?productId=" + productId);
        ResultProductDetailWithRelationshipsByProductIdDto? value = await responseMessage.Content.ReadFromJsonAsync<ResultProductDetailWithRelationshipsByProductIdDto>();
        return value;
    }

    public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateProductDetailDto>("productdetails", updateProductDetailDto);
    }
}
