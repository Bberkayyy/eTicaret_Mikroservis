using e_Ticaret.WebUI.Services.CatalogServices.BrandServices;
using e_Ticaret.WebUIDtos.CatalogDtos.BrandDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace e_Ticaret.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/brand")]
public class BrandController : Controller
{
    private readonly IBrandService _brandService;

    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [Route("index")]
    public async Task<IActionResult> Index()
    {
        GetBrandViewbagList();
        ViewBag.v3 = "Marka Listesi";

        IEnumerable<ResultBrandDto>? values = await _brandService.GetAllBrandAsync();
        return View(values);
    }
    [HttpGet]
    [Route("createbrand")]
    public IActionResult CreateBrand()
    {
        GetBrandViewbagList();
        ViewBag.v3 = "Marka Ekleme Sayfası";
        return View();
    }
    [HttpPost]
    [Route("createbrand")]
    public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
    {
        await _brandService.CreateBrandAsync(createBrandDto);
        return RedirectToAction("index", "brand", new { area = "admin" });
    }
    [Route("deletebrand/{id}")]
    public async Task<IActionResult> DeleteBrand(string id)
    {
        await _brandService.DeleteBrandAsync(id);
        return RedirectToAction("index", "brand", new { area = "admin" });
    }
    [HttpGet]
    [Route("updatebrand/{id}")]
    public async Task<IActionResult> UpdateBrand(string id)
    {
        GetBrandViewbagList();
        ViewBag.v3 = "Marka Güncelleme Sayfası";
        UpdateBrandDto? value = await _brandService.GetBrandForUpdateAsync(id);
        return View(value);
    }
    [HttpPost]
    [Route("updatebrand/{id}")]
    public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
    {
        await _brandService.UpdateBrandAsync(updateBrandDto);
        return RedirectToAction("index", "brand", new { area = "admin" });
    }
    private void GetBrandViewbagList()
    {
        ViewBag.v1 = "Anasayfa";
        ViewBag.v2 = "Marka İşlemleri";
    }
}
