using e_Ticaret.WebUI.Services.CatalogServices.SpecialOfferServices;
using e_Ticaret.WebUIDtos.CatalogDtos.SpecialOfferDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace e_Ticaret.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/specialoffer")]
public class SpecialOfferController : Controller
{
    private readonly ISpecialOfferService _specialOfferService;

    public SpecialOfferController(ISpecialOfferService specialOfferService)
    {
        _specialOfferService = specialOfferService;
    }

    [Route("index")]
    public async Task<IActionResult> Index()
    {
        GetSpecialOfferViewbagList();
        ViewBag.v3 = "Özel Teklif Listesi";
        IEnumerable<ResultSpecialOfferDto>? values = await _specialOfferService.GetAllSpecialOfferAsync();
        return View(values);
    }
    [HttpGet]
    [Route("createspecialoffer")]
    public IActionResult CreateSpecialOffer()
    {
        GetSpecialOfferViewbagList();
        ViewBag.v3 = "Özel Teklif Ekleme Sayfası";
        return View();
    }
    [HttpPost]
    [Route("createspecialoffer")]
    public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
    {
        await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
        return RedirectToAction("index", "specialoffer", new { area = "admin" });
    }
    [Route("deletespecialoffer/{id}")]
    public async Task<IActionResult> DeleteSpecialOffer(string id)
    {
        await _specialOfferService.DeleteSpecialOfferAsync(id);
        return RedirectToAction("index", "specialoffer", new { area = "admin" });
    }
    [HttpGet]
    [Route("updatespecialoffer/{id}")]
    public async Task<IActionResult> UpdateSpecialOffer(string id)
    {
        GetSpecialOfferViewbagList();
        ViewBag.v3 = "Özel Teklif Güncelleme Sayfası";
        UpdateSpecialOfferDto? value = await _specialOfferService.GetSpecialOfferForUpdateAsync(id);
        return View(value);
    }
    [HttpPost]
    [Route("updatespecialoffer/{id}")]
    public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
    {
        await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
        return RedirectToAction("index", "specialoffer", new { area = "admin" });
    }
    private void GetSpecialOfferViewbagList()
    {
        ViewBag.v1 = "Anasayfa";
        ViewBag.v2 = "Özel Teklif İşlemleri";
    }
}
