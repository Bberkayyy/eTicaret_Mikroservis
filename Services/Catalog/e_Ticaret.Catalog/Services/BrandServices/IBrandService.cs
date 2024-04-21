using e_Ticaret.Catalog.Dtos.BrandDtos;

namespace e_Ticaret.Catalog.Services.BrandServices;

public interface IBrandService
{
    Task<List<GetAllBrandResponseDto>> GetAllBrandAsync();
    Task CreateBrandAsync(CreateBrandRequestDto createBrandRequestDto);
    Task UpdateBrandAsync(UpdateBrandRequestDto updateBrandRequestDto);
    Task DeleteBrandAsync(string id);
    Task<GetBrandResponseDto> GetBrandAsync(string id);
}