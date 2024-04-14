using e_Ticaret.Catalog.Dtos.ProductDetailDtos;

namespace e_Ticaret.Catalog.Services.ProductDetailServices;

public interface IProductDetailService
{
    Task<List<GetAllProductDetailResponseDto>> GetAllProductDetailAsync();
    Task CreateProductDetailAsync(CreateProductDetailRequestDto createProductDetailRequestDto);
    Task UpdateProductDetailAsync(UpdateProductDetailRequestDto updateProductDetailRequestDto);
    Task DeleteProductDetailAsync(string id);
    Task<GetProductDetailResponseDto> GetProductDetailAsync(string id);
}
