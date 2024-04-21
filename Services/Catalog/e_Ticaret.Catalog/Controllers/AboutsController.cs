using e_Ticaret.Catalog.Dtos.AboutDtos;
using e_Ticaret.Catalog.Services.AboutServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.Catalog.Controllers;

[Route("api/abouts")]
[ApiController]
public class AboutsController : ControllerBase
{
    private readonly IAboutService _aboutService;

    public AboutsController(IAboutService AboutService)
    {
        _aboutService = AboutService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<GetAllAboutResponseDto> values = await _aboutService.GetAllAboutAsync();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAbout(string id)
    {
        GetAboutResponseDto value = await _aboutService.GetAboutAsync(id);
        return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> CreateAbout(CreateAboutRequestDto createAboutRequestDto)
    {
        await _aboutService.CreateAboutAsync(createAboutRequestDto);
        return Ok("Hakkımızda başarıyla eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteAbout(string id)
    {
        await _aboutService.DeleteAboutAsync(id);
        return Ok("Hakkımızda başarıyla silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateAbout(UpdateAboutRequestDto updateAboutRequestDto)
    {
        await _aboutService.UpdateAboutAsync(updateAboutRequestDto);
        return Ok("Hakkımızda başarıyla güncellendi.");
    }
}
