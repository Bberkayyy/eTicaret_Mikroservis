using e_Ticaret.WebUIDtos.CatalogDtos.AboutDtos;

namespace e_Ticaret.WebUI.Services.CatalogServices.AboutServices;

public interface IAboutService
{
    Task<List<ResultAboutDto>> GetAllAboutAsync();
    Task CreateAboutAsync(CreateAboutDto createAboutDto);
    Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
    Task DeleteAboutAsync(string id);
    Task<UpdateAboutDto> GetAboutForUpdateAsync(string id);
}
