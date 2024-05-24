using e_Ticaret.WebUIDtos.CatalogDtos.DiscountOfferDtos;

namespace e_Ticaret.WebUI.Services.CatalogServices.DiscountOfferServices;

public interface IDiscountOfferService
{
    Task<List<ResultDiscountOfferDto>> GetAllDiscountOfferAsync();
    Task CreateDiscountOfferAsync(CreateDiscountOfferDto createDiscountOfferDto);
    Task UpdateDiscountOfferAsync(UpdateDiscountOfferDto updateDiscountOfferDto);
    Task DeleteDiscountOfferAsync(string id);
    Task<UpdateDiscountOfferDto> GetDiscountOfferForUpdateAsync(string id);
    Task ChangeStatusToTrueAsync(string id);
    Task ChangeStatusToFalseAsync(string id);
}
