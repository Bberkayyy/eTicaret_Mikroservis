using e_Ticaret.Catalog.Dtos.SpecialOfferDtos;
using e_Ticaret.Catalog.Services.SpecialOfferServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.Catalog.Controllers;

[Route("api/specialoffers")]
[ApiController]
public class SpecialOffersController : ControllerBase
{
    private readonly ISpecialOfferService _specialOfferService;

    public SpecialOffersController(ISpecialOfferService specialOfferService)
    {
        _specialOfferService = specialOfferService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<GetAllSpecialOfferResponseDto> values = await _specialOfferService.GetAllSpecialOfferAsync();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSpecialOffer(string id)
    {
        GetSpecialOfferResponseDto value = await _specialOfferService.GetSpecialOfferAsync(id);
        return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferRequestDto createSpecialOfferRequestDto)
    {
        await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferRequestDto);
        return Ok("Özel teklif başarıyla eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteSpecialOffer(string id)
    {
        await _specialOfferService.DeleteSpecialOfferAsync(id);
        return Ok("Özel teklif başarıyla silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferRequestDto updateSpecialOfferRequestDto)
    {
        await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferRequestDto);
        return Ok("Özel teklif başarıyla güncellendi.");
    }
}
