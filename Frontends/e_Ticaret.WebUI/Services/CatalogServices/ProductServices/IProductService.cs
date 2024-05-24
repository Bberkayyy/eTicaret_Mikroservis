using e_Ticaret.WebUIDtos.CatalogDtos.ProductDtos;

namespace e_Ticaret.WebUI.Services.CatalogServices.ProductServices;

public interface IProductService
{
    Task<List<ResultProductDto>> GetAllProductAsync();
    Task<List<ResultProductWithRelationshipsDto>> GetAllProductWithRelationshipsAsync();
    Task<List<ResultProductWithRelationshipsByCategoryIdDto>> GetAllProductWithRelationshipsByCategoryIdAsync(string categoryId);
    Task CreateProductAsync(CreateProductDto createProductDto);
    Task UpdateProductAsync(UpdateProductDto updateProductDto);
    Task DeleteProductAsync(string id);
    Task<UpdateProductDto> GetProductForUpdateAsync(string id);
    Task<GetProductByIdDto> GetProductByIdAsync(string id);
}
