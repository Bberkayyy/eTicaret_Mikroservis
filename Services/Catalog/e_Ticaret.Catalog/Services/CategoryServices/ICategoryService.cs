using e_Ticaret.Catalog.Dtos.CategoryDtos;

namespace e_Ticaret.Catalog.Services.CategoryServices;

public interface ICategoryService
{
    Task<List<GetAllCategoryResponseDto>> GetAllCategoryAsync();
    Task CreateCategoryAsync(CreateCategoryRequestDto createCategoryRequestDto);
    Task UpdateCategoryAsync(UpdateCategoryRequestDto updateCategoryRequestDto);
    Task DeleteCategoryAsync(string id);
    Task<GetCategoryResponseDto> GetCategoryAsync(string id);
}