using e_Ticaret.WebUIDtos.DiscountDtos.DiscountCouponDtos;

namespace e_Ticaret.WebUI.Services.DiscountServices.DiscountCouponServices;

public interface IDiscountCouponService
{
    Task<GetDiscountCouponDetailByCode> GetDiscountCoupon(string code);
}
