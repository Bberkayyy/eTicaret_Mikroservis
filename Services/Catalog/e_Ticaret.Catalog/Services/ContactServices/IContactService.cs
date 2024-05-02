using e_Ticaret.Catalog.Dtos.ContactDtos;

namespace e_Ticaret.Catalog.Services.ContactServices;

public interface IContactService
{
    Task<List<GetAllContactResponseDto>> GetAllContactAsync();
    Task CreateContactAsync(CreateContactRequestDto createContactRequestDto);
    Task UpdateContactAsync(UpdateContactRequestDto updateContactRequestDto);
    Task DeleteContactAsync(string id);
    Task<GetContactResponseDto> GetContactAsync(string id);
    void ChangeIsReadToTrue(string id);
}
