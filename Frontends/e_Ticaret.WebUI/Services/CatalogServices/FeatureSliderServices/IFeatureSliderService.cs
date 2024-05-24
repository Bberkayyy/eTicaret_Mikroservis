using e_Ticaret.WebUIDtos.CatalogDtos.FeatureSliderDtos;

namespace e_Ticaret.WebUI.Services.CatalogServices.FeatureSliderServices;

public interface IFeatureSliderService
{
    Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync();
    Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
    Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
    Task DeleteFeatureSliderAsync(string id);
    Task<UpdateFeatureSliderDto> GetFeatureSliderForUpdateAsync(string id);
    Task ChangeStatusToTrueAsync(string id);
    Task ChangeStatusToFalseAsync(string id);
}
