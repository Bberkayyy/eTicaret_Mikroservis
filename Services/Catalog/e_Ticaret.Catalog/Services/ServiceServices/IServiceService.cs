using e_Ticaret.Catalog.Dtos.ServiceDtos;

namespace e_Ticaret.Catalog.Services.ServiceServices;

public interface IServiceService
{
    Task<List<GetAllServiceResponseDto>> GetAllServiceAsync();
    Task CreateServiceAsync(CreateServiceRequestDto createServiceRequestDto);
    Task UpdateServiceAsync(UpdateServiceRequestDto updateServiceRequestDto);
    Task DeleteServiceAsync(string id);
    Task<GetServiceResponseDto> GetServiceAsync(string id);
}
