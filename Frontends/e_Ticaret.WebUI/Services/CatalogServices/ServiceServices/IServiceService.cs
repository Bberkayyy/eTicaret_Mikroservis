using e_Ticaret.WebUIDtos.CatalogDtos.ServiceDtos;

namespace e_Ticaret.WebUI.Services.CatalogServices.ServiceServices;

public interface IServiceService
{
    Task<List<ResultServiceDto>> GetAllServiceAsync();
    Task CreateServiceAsync(CreateServiceDto createServiceDto);
    Task UpdateServiceAsync(UpdateServiceDto updateServiceDto);
    Task DeleteServiceAsync(string id);
    Task<UpdateServiceDto> GetServiceForUpdateAsync(string id);
}
