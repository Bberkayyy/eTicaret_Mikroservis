using e_Ticaret.Catalog.Dtos.ServiceDtos;
using e_Ticaret.Catalog.Services.ServiceServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.Catalog.Controllers;

[Route("api/services")]
[ApiController]
public class ServicesController : ControllerBase
{
    private readonly IServiceService _serviceService;

    public ServicesController(IServiceService ServiceService)
    {
        _serviceService = ServiceService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<GetAllServiceResponseDto> values = await _serviceService.GetAllServiceAsync();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetService(string id)
    {
        GetServiceResponseDto value = await _serviceService.GetServiceAsync(id);
        return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> CreateService(CreateServiceRequestDto createServiceRequestDto)
    {
        await _serviceService.CreateServiceAsync(createServiceRequestDto);
        return Ok("Hizmet başarıyla eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteService(string id)
    {
        await _serviceService.DeleteServiceAsync(id);
        return Ok("Hizmet başarıyla silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateService(UpdateServiceRequestDto updateServiceRequestDto)
    {
        await _serviceService.UpdateServiceAsync(updateServiceRequestDto);
        return Ok("Hizmet başarıyla güncellendi.");
    }
}
