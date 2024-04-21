using e_Ticaret.Catalog.Dtos.DiscountOfferDtos;

namespace e_Ticaret.Catalog.Services.DiscountOfferServices;

public interface IDiscountOfferService
{
    Task<List<GetAllDiscountOfferResponseDto>> GetAllDiscountOfferAsync();
    Task CreateDiscountOfferAsync(CreateDiscountOfferRequestDto createDiscountOfferRequestDto);
    Task UpdateDiscountOfferAsync(UpdateDiscountOfferRequestDto updateDiscountOfferRequestDto);
    Task DeleteDiscountOfferAsync(string id);
    Task<GetDiscountOfferResponseDto> GetDiscountOfferAsync(string id);
    Task ChangeStatusToTrue(string id);
    Task ChangeStatusToFalse(string id);
}
