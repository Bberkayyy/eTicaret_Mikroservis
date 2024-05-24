using e_Ticaret.WebUIDtos.CatalogDtos.ContactDtos;

namespace e_Ticaret.WebUI.Services.CatalogServices.ContactServices;

public interface IContactService
{
    Task<List<ResultContactDto>> GetAllContactAsync();
    Task CreateContactAsync(CreateContactDto createContactDto);
    Task DeleteContactAsync(string id);
    Task<ResultContactDto> GetContactForDetailAsync(string id);
    Task ChangeIsReadToTrueAsync(string id);
}
