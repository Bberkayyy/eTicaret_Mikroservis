namespace e_Ticaret.WebUI.Services.StatisticServices.DiscountStatisticServices;

public interface IDiscountStatisticService
{
    Task<int> GetDiscountCouponCount();
}
