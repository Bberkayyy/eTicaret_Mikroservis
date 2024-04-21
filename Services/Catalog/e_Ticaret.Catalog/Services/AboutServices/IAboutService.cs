using e_Ticaret.Catalog.Dtos.AboutDtos;

namespace e_Ticaret.Catalog.Services.AboutServices;

public interface IAboutService
{
    Task<List<GetAllAboutResponseDto>> GetAllAboutAsync();
    Task CreateAboutAsync(CreateAboutRequestDto createAboutRequestDto);
    Task UpdateAboutAsync(UpdateAboutRequestDto updateAboutRequestDto);
    Task DeleteAboutAsync(string id);
    Task<GetAboutResponseDto> GetAboutAsync(string id);
}