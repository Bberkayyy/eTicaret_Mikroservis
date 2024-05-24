using e_Ticaret.WebUI.Services.CatalogServices.AboutServices;
using e_Ticaret.WebUIDtos.CatalogDtos.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace e_Ticaret.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/about")]
public class AboutController : Controller
{
    private readonly IAboutService _aboutService;

    public AboutController(IAboutService aboutService)
    {
        _aboutService = aboutService;
    }

    [Route("index")]
    public async Task<IActionResult> Index()
    {
        GetAboutViewbagList();
        ViewBag.v3 = "Hakkımızda Listesi";
        List<ResultAboutDto> values = await _aboutService.GetAllAboutAsync();
        return View(values);

    }
    [HttpGet]
    [Route("createabout")]
    public IActionResult CreateAbout()
    {
        GetAboutViewbagList();
        ViewBag.v3 = "Hakkımızda Ekleme Sayfası";
        return View();
    }
    [HttpPost]
    [Route("createabout")]
    public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
    {
        await _aboutService.CreateAboutAsync(createAboutDto);
        return RedirectToAction("index", "about", new { area = "admin" });
    }
    [Route("deleteabout/{id}")]
    public async Task<IActionResult> DeleteAbout(string id)
    {
        await _aboutService.DeleteAboutAsync(id);
        return RedirectToAction("index", "about", new { area = "admin" });
    }
    [HttpGet]
    [Route("updateabout/{id}")]
    public async Task<IActionResult> UpdateAbout(string id)
    {
        GetAboutViewbagList();
        ViewBag.v3 = "Hakkımızda Güncelleme Sayfası";
        UpdateAboutDto? value = await _aboutService.GetAboutForUpdateAsync(id);
        return View(value);
    }
    [HttpPost]
    [Route("updateabout/{id}")]
    public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
    {
        await _aboutService.UpdateAboutAsync(updateAboutDto);
        return RedirectToAction("index", "about", new { area = "admin" });
    }
    private void GetAboutViewbagList()
    {
        ViewBag.v1 = "Anasayfa";
        ViewBag.v2 = "Hakkımızda İşlemleri";
    }
}
