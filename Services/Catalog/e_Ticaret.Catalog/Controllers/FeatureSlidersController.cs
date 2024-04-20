using e_Ticaret.Catalog.Dtos.FeatureSliderDtos;
using e_Ticaret.Catalog.Services.FeatureSliderServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.Catalog.Controllers;

[Authorize]
[Route("api/featuresliders")]
[ApiController]
public class FeatureSlidersController : ControllerBase
{
    private readonly IFeatureSliderService _featureSliderService;

    public FeatureSlidersController(IFeatureSliderService featureSliderService)
    {
        _featureSliderService = featureSliderService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<GetAllFeatureSliderResponseDto> values = await _featureSliderService.GetAllFeatureSliderAsync();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetFeatureSlider(string id)
    {
        GetFeatureSliderResponseDto value = await _featureSliderService.GetFeatureSliderAsync(id);
        return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderRequestDto createFeatureSliderRequestDto)
    {
        await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderRequestDto);
        return Ok("Öne çıkan görsel başarıyla eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteFeatureSlider(string id)
    {
        await _featureSliderService.DeleteFeatureSliderAsync(id);
        return Ok("Öne çıkan görsel başarıyla silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderRequestDto updateFeatureSliderRequestDto)
    {
        await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderRequestDto);
        return Ok("Öne çıkan görsel başarıyla güncellendi.");
    }
}
