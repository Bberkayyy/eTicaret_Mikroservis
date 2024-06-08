using e_Ticaret.WebUIDtos.OrderDtos.AddressDtos;

namespace e_Ticaret.WebUI.Services.OrderServices.AddressServices;

public interface IAddressService
{
    Task<List<ResultAddressDto>> GetAllAddressAsync();
    Task CreateAddressAsync(CreateAddressDto createAddressDto);
    Task UpdateAddressAsync(UpdateAddressDto updateAddressDto);
    Task DeleteAddressAsync(int id);
    Task<UpdateAddressDto> GetAddressForUpdateAsync(int id);
}
