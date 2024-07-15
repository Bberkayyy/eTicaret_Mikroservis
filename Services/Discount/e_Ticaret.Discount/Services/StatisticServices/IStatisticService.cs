namespace e_Ticaret.Discount.Services.StatisticServices;

public interface IStatisticService
{
    Task<int> GetDiscountCouponCount();
}
