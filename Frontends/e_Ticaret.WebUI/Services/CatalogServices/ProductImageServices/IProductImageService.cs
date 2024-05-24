using e_Ticaret.WebUIDtos.CatalogDtos.ProductImageDtos;

namespace e_Ticaret.WebUI.Services.CatalogServices.ProductImageServices;

public interface IProductImageService
{
    Task<List<ResultProductImageDto>> GetAllProductImageAsync();
    Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
    Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
    Task DeleteProductImageAsync(string id);
    Task<UpdateProductImageDto> GetProductImageForUpdateAsync(string id);
    Task<ResultProductImageWithRelationshipsByProductIdDto> GetProductImageWithRelationshipsByProductIdAsync(string productId);
}
