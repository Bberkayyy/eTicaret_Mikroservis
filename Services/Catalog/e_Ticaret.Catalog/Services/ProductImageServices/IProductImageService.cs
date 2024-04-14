using e_Ticaret.Catalog.Dtos.ProductImageDtos;

namespace e_Ticaret.Catalog.Services.ProductImageServices;

public interface IProductImageService
{
    Task<List<GetAllProductImageResponseDto>> GetAllProductImageAsync();
    Task CreateProductImageAsync(CreateProductImageRequestDto createProductImageRequestDto);
    Task UpdateProductImageAsync(UpdateProductImageRequestDto updateProductImageRequestDto);
    Task DeleteProductImageAsync(string id);
    Task<GetProductImageResponseDto> GetProductImageAsync(string id);
}
