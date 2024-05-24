using e_Ticaret.WebUIDtos.CatalogDtos.BrandDtos;

namespace e_Ticaret.WebUI.Services.CatalogServices.BrandServices;

public interface IBrandService
{
    Task<List<ResultBrandDto>> GetAllBrandAsync();
    Task CreateBrandAsync(CreateBrandDto createBrandDto);
    Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
    Task DeleteBrandAsync(string id);
    Task<UpdateBrandDto> GetBrandForUpdateAsync(string id);
}
