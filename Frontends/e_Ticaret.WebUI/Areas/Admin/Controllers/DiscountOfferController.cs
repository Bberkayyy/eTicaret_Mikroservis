using e_Ticaret.WebUI.Services.CatalogServices.DiscountOfferServices;
using e_Ticaret.WebUIDtos.CatalogDtos.DiscountOfferDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace e_Ticaret.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/discountoffer")]
public class DiscountOfferController : Controller
{
    private readonly IDiscountOfferService _discountOfferService;

    public DiscountOfferController(IDiscountOfferService discountOfferService)
    {
        _discountOfferService = discountOfferService;
    }

    [Route("index")]
    public async Task<IActionResult> Index()
    {
        GetDiscountOfferViewbagList();
        ViewBag.v3 = "İndirim Teklifi Listesi";
        IEnumerable<ResultDiscountOfferDto>? values = await _discountOfferService.GetAllDiscountOfferAsync();
        return View(values);
    }
    [HttpGet]
    [Route("creatediscountoffer")]
    public IActionResult CreateDiscountOffer()
    {
        GetDiscountOfferViewbagList();
        ViewBag.v3 = "İndirim Teklifi Ekleme Sayfası";
        return View();
    }
    [HttpPost]
    [Route("creatediscountoffer")]
    public async Task<IActionResult> CreateDiscountOffer(CreateDiscountOfferDto createDiscountOfferDto)
    {
        await _discountOfferService.CreateDiscountOfferAsync(createDiscountOfferDto);
        return RedirectToAction("index", "discountoffer", new { area = "Admin" });
    }
    [Route("deletediscountoffer/{id}")]
    public async Task<IActionResult> DeleteDiscountOffer(string id)
    {
        await _discountOfferService.DeleteDiscountOfferAsync(id);
        return RedirectToAction("index", "discountoffer", new { area = "admin" });
    }
    [HttpGet]
    [Route("updatediscountoffer/{id}")]
    public async Task<IActionResult> UpdateDiscountOffer(string id)
    {
        GetDiscountOfferViewbagList();
        ViewBag.v3 = "İndirim Teklifi Güncelleme Sayfası";
        UpdateDiscountOfferDto? value = await _discountOfferService.GetDiscountOfferForUpdateAsync(id);
        return View(value);

    }
    [HttpPost]
    [Route("updatediscountoffer/{id}")]
    public async Task<IActionResult> UpdateDiscountOffer(UpdateDiscountOfferDto updateDiscountOfferDto)
    {
        await _discountOfferService.UpdateDiscountOfferAsync(updateDiscountOfferDto);
        return RedirectToAction("index", "discountoffer", new { area = "admin" });
    }
    private void GetDiscountOfferViewbagList()
    {
        ViewBag.v1 = "Anasayfa";
        ViewBag.v2 = "İndirim Teklifi İşlemleri";
    }
}
