using e_Ticaret.Catalog.Dtos.ProductDtos;

namespace e_Ticaret.Catalog.Services.ProductServices;

public interface IProductService
{
    Task<List<GetAllProductResponseDto>> GetAllProductAsync();
    Task<List<GetAllProductWithRelationshipsResponseDto>> GetAllProductWithRelationshipsAsync();
    Task CreateProductAsync(CreateProductRequestDto createProductRequestDto);
    Task UpdateProductAsync(UpdateProductRequestDto updateProductRequestDto);
    Task DeleteProductAsync(string id);
    Task<GetProductResponseDto> GetProductAsync(string id);
    Task<List<GetAllProductWtihRelationshipsByCategoryIdResponseDto>> GetAllProductWithRelationshipsByCategoryIdAsync(string categoryId);
}
