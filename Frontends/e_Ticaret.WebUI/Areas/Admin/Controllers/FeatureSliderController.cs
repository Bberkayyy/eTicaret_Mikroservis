using e_Ticaret.WebUI.Services.CatalogServices.FeatureSliderServices;
using e_Ticaret.WebUIDtos.CatalogDtos.FeatureSliderDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace e_Ticaret.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/featureslider")]
public class FeatureSliderController : Controller
{
    private readonly IFeatureSliderService _featureSliderService;

    public FeatureSliderController(IFeatureSliderService featureSliderService)
    {
        _featureSliderService = featureSliderService;
    }

    [Route("index")]
    public async Task<IActionResult> Index()
    {
        GetFeatureSliderViewbagList();
        ViewBag.v3 = "Öne Çıkan Görsel Listesi";
        IEnumerable<ResultFeatureSliderDto>? values = await _featureSliderService.GetAllFeatureSliderAsync();
        return View(values);
    }
    [HttpGet]
    [Route("createfeatureslider")]
    public IActionResult CreateFeatureSlider()
    {
        GetFeatureSliderViewbagList();
        ViewBag.v3 = "Öne Çıkan Görsel Sayfası";
        return View();
    }
    [HttpPost]
    [Route("createfeatureslider")]
    public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
    {
        await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
        return RedirectToAction("index", "featureslider", new { area = "Admin" });
    }
    [Route("deletefeatureslider/{id}")]
    public async Task<IActionResult> DeleteFeatureSlider(string id)
    {
        await _featureSliderService.DeleteFeatureSliderAsync(id);
        return RedirectToAction("index", "featureslider", new { area = "admin" });
    }
    [HttpGet]
    [Route("updatefeatureslider/{id}")]
    public async Task<IActionResult> UpdateFeatureSlider(string id)
    {
        GetFeatureSliderViewbagList();
        ViewBag.v3 = "Öne Çıkan Görsel Güncelleme Sayfası";
        UpdateFeatureSliderDto? value = await _featureSliderService.GetFeatureSliderForUpdateAsync(id);
        return View(value);
    }
    [HttpPost]
    [Route("updatefeatureslider/{id}")]
    public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
    {
        await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
        return RedirectToAction("index", "featureslider", new { area = "admin" });
    }
    private void GetFeatureSliderViewbagList()
    {
        ViewBag.v1 = "Anasayfa";
        ViewBag.v2 = "Öne Çıkan Görsel İşlemleri";
    }
}
