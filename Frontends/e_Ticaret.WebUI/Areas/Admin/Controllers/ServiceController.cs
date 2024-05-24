using e_Ticaret.WebUI.Services.CatalogServices.ServiceServices;
using e_Ticaret.WebUIDtos.CatalogDtos.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace e_Ticaret.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/service")]
public class ServiceController : Controller
{
    private readonly IServiceService _serviceService;

    public ServiceController(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    [Route("index")]
    public async Task<IActionResult> Index()
    {
        GetServiceViewbagList();
        ViewBag.v3 = "Hizmet Listesi";
        IEnumerable<ResultServiceDto>? values = await _serviceService.GetAllServiceAsync();
        return View(values);
    }
    [HttpGet]
    [Route("createservice")]
    public IActionResult CreateService()
    {
        GetServiceViewbagList();
        ViewBag.v3 = "Hizmet Ekleme Sayfası";
        return View();
    }
    [HttpPost]
    [Route("createservice")]
    public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
    {
        await _serviceService.CreateServiceAsync(createServiceDto);
        return RedirectToAction("index", "service", new { area = "admin" });
    }
    [Route("deleteservice/{id}")]
    public async Task<IActionResult> DeleteService(string id)
    {
        await _serviceService.DeleteServiceAsync(id);
        return RedirectToAction("index", "service", new { area = "admin" });
    }
    [HttpGet]
    [Route("updateservice/{id}")]
    public async Task<IActionResult> UpdateService(string id)
    {
        GetServiceViewbagList();
        ViewBag.v3 = "Hizmet Güncelleme Sayfası";
        UpdateServiceDto? value = await _serviceService.GetServiceForUpdateAsync(id);
        return View(value);
    }
    [HttpPost]
    [Route("updateservice/{id}")]
    public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
    {
        await _serviceService.UpdateServiceAsync(updateServiceDto);
        return RedirectToAction("index", "service", new { area = "admin" });
    }
    private void GetServiceViewbagList()
    {
        ViewBag.v1 = "Anasayfa";
        ViewBag.v2 = "Hizmet İşlemleri";
    }
}
