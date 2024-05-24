using e_Ticaret.WebUIDtos.CatalogDtos.ProductDetailDtos;

namespace e_Ticaret.WebUI.Services.CatalogServices.ProductDetailServices;

public interface IProductDetailService
{
    Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
    Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
    Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
    Task DeleteProductDetailAsync(string id);
    Task<UpdateProductDetailDto> GetProductDetailForUpdateAsync(string id);
    Task<ResultProductDetailWithRelationshipsByProductIdDto> GetProductDetailWithRelationshipsByProductIdAsync(string productId);
}
