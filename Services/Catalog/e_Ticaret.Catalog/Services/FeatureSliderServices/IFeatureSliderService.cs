using e_Ticaret.Catalog.Dtos.FeatureSliderDtos;

namespace e_Ticaret.Catalog.Services.FeatureSliderServices;

public interface IFeatureSliderService
{
    Task<List<GetAllFeatureSliderResponseDto>> GetAllFeatureSliderAsync();
    Task CreateFeatureSliderAsync(CreateFeatureSliderRequestDto createFeatureSliderRequestDto);
    Task UpdateFeatureSliderAsync(UpdateFeatureSliderRequestDto updateFeatureSliderRequestDto);
    Task DeleteFeatureSliderAsync(string id);
    Task<GetFeatureSliderResponseDto> GetFeatureSliderAsync(string id);
    Task ChangeStatusToTrue(string id);
    Task ChangeStatusToFalse(string id);
}
