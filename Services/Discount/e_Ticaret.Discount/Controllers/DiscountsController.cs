using e_Ticaret.Discount.Dtos;
using e_Ticaret.Discount.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.Discount.Controllers;

[Route("api/discounts")]
[ApiController]
public class DiscountsController : ControllerBase
{
    private readonly IDiscountService _discountService;

    public DiscountsController(IDiscountService discountService)
    {
        _discountService = discountService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<GetAllDiscountCouponResponseDto> values = await _discountService.GetAllDiscountCouponAsync();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDiscountCoupon(int id)
    {
        GetDiscountCouponResponseDto value = await _discountService.GetDiscountCouponAsync(id);
        return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponRequestDto createCouponRequestDto)
    {
        await _discountService.CreateDiscountCouponAsync(createCouponRequestDto);
        return Ok("İndirim kuponu başarıyla eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteDiscountCoupon(int id)
    {
        await _discountService.DeleteDiscountCouponAsync(id);
        return Ok("İndirim kuponu başarıyla silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponRequestDto updateCouponRequestDto)
    {
        await _discountService.UpdateDiscountCouponAsync(updateCouponRequestDto);
        return Ok("İndirim kuponu başarıyla güncellendi.");
    }
}
