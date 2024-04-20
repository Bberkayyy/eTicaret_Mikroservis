using e_Ticaret.Catalog.Dtos.SpecialOfferDtos;

namespace e_Ticaret.Catalog.Services.SpecialOfferServices;

public interface ISpecialOfferService
{
    Task<List<GetAllSpecialOfferResponseDto>> GetAllSpecialOfferAsync();
    Task CreateSpecialOfferAsync(CreateSpecialOfferRequestDto createSpecialOfferRequestDto);
    Task UpdateSpecialOfferAsync(UpdateSpecialOfferRequestDto updateSpecialOfferRequestDto);
    Task DeleteSpecialOfferAsync(string id);
    Task<GetSpecialOfferResponseDto> GetSpecialOfferAsync(string id);
}
