using e_Ticaret.Catalog.Dtos.DiscountOfferDtos;
using e_Ticaret.Catalog.Services.DiscountOfferServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.Catalog.Controllers;

[Route("api/discountoffers")]
[ApiController]
public class DiscountOffersController : ControllerBase
{
    private readonly IDiscountOfferService _discountOfferService;

    public DiscountOffersController(IDiscountOfferService DiscountOfferService)
    {
        _discountOfferService = DiscountOfferService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<GetAllDiscountOfferResponseDto> values = await _discountOfferService.GetAllDiscountOfferAsync();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDiscountOffer(string id)
    {
        GetDiscountOfferResponseDto value = await _discountOfferService.GetDiscountOfferAsync(id);
        return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> CreateDiscountOffer(CreateDiscountOfferRequestDto createDiscountOfferRequestDto)
    {
        await _discountOfferService.CreateDiscountOfferAsync(createDiscountOfferRequestDto);
        return Ok("İndirim teklifi başarıyla eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteDiscountOffer(string id)
    {
        await _discountOfferService.DeleteDiscountOfferAsync(id);
        return Ok("İndirim teklifi başarıyla silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateDiscountOffer(UpdateDiscountOfferRequestDto updateDiscountOfferRequestDto)
    {
        await _discountOfferService.UpdateDiscountOfferAsync(updateDiscountOfferRequestDto);
        return Ok("İndirim teklifi başarıyla güncellendi.");
    }
}
