using e_Ticaret.WebUI.Services.StatisticServices.CatalogStatisticServices;
using e_Ticaret.WebUI.Services.StatisticServices.CommentStatisticServices;
using e_Ticaret.WebUI.Services.StatisticServices.DiscountStatisticServices;
using e_Ticaret.WebUI.Services.StatisticServices.UserStatisticServices;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/statistic")]
public class StatisticController : Controller
{
    private readonly ICatalogStatisticService _catalogStatisticService;
    private readonly IUserStatisticService _userStatisticService;
    private readonly ICommentStatisticService _commentStatisticService;
    private readonly IDiscountStatisticService _discountStatisticService;

    public StatisticController(ICatalogStatisticService catalogStatisticService, IUserStatisticService userStatisticService, ICommentStatisticService commentStatisticService, IDiscountStatisticService discountStatisticService)
    {
        _catalogStatisticService = catalogStatisticService;
        _userStatisticService = userStatisticService;
        _commentStatisticService = commentStatisticService;
        _discountStatisticService = discountStatisticService;
    }

    [Route("index")]
    public async Task<IActionResult> Index()
    {
        GetAboutViewbagList();
        ViewBag.brandCount = await _catalogStatisticService.GetBrandCountAsync();
        ViewBag.categoryCount = await _catalogStatisticService.GetCategoryCountAsync();
        ViewBag.productCount = await _catalogStatisticService.GetProductCountAsync();
        ViewBag.productNameOfMaxPriceProduct = await _catalogStatisticService.GetProductNameOfMaxPriceProduct();
        ViewBag.productNameOfMinPriceProduct = await _catalogStatisticService.GetProductNameOfMinPriceProduct();

        ViewBag.userCount = await _userStatisticService.GetUserCount();

        ViewBag.discountCouponCount = await _discountStatisticService.GetDiscountCouponCount();

        ViewBag.activeCommentCount = await _commentStatisticService.GetActiveCommentCount();
        ViewBag.passiveCommentCount = await _commentStatisticService.GetPassiveCommentCount();
        ViewBag.commentCount = await _commentStatisticService.GetCommentCount();
        return View();
    }
    private void GetAboutViewbagList()
    {
        ViewBag.v1 = "Anasayfa";
        ViewBag.v2 = "İstatistikler";
        ViewBag.v3 = "Site İstatistikleri";
    }
}
