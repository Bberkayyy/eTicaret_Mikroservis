using e_Ticaret.Discount.Dtos;

namespace e_Ticaret.Discount.Services;

public interface IDiscountService
{
    Task<List<GetAllDiscountCouponResponseDto>> GetAllDiscountCouponAsync();
    Task CreateDiscountCouponAsync(CreateDiscountCouponRequestDto createCouponRequestDto);
    Task UpdateDiscountCouponAsync(UpdateDiscountCouponRequestDto updateCouponRequestDto);
    Task DeleteDiscountCouponAsync(int id);
    Task<GetDiscountCouponResponseDto> GetDiscountCouponAsync(int id);
}
