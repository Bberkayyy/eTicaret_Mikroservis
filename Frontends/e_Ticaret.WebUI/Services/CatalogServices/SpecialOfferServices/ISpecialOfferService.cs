using e_Ticaret.WebUIDtos.CatalogDtos.SpecialOfferDtos;

namespace e_Ticaret.WebUI.Services.CatalogServices.SpecialOfferServices;

public interface ISpecialOfferService
{
    Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync();
    Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto);
    Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
    Task DeleteSpecialOfferAsync(string id);
    Task<UpdateSpecialOfferDto> GetSpecialOfferForUpdateAsync(string id);
}
