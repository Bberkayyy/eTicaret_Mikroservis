using e_Ticaret.WebUIDtos.CatalogDtos.CategoryDtos;

namespace e_Ticaret.WebUI.Services.CatalogServices.CategoryServices;

public interface ICategoryService
{
    Task<List<ResultCategoryDto>> GetAllCategoryAsync();
    Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
    Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
    Task DeleteCategoryAsync(string id);
    Task<UpdateCategoryDto> GetCategoryForUpdateAsync(string id);
    Task<GetCategoryByIdDto> GetCategoryById(string id);
}
