using e_Ticaret.WebUI.Services.CargoServices.CompanyServices;
using e_Ticaret.WebUIDtos.CargoDtos.CompanyDtos;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/cargocompany")]
public class CompanyController : Controller
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [Route("companies")]
    public async Task<IActionResult> CompanyList()
    {
        GetCompanyViewbagList();
        ViewBag.v3 = "Kargo Şirketleri Listesi";
        List<ResultCompanyDto> values = await _companyService.GetAllCompanyAsync();
        return View(values);
    }
    [HttpGet]
    [Route("createcompany")]
    public IActionResult CreateCompany()
    {
        GetCompanyViewbagList();
        ViewBag.v3 = "Kargo Şirketi Ekleme Sayfası";
        return View();
    }
    [HttpPost]
    [Route("createcompany")]
    public async Task<IActionResult> CreateCompany(CreateCompanyDto createCompanyDto)
    {
        await _companyService.CreateCompanyAsync(createCompanyDto);
        return RedirectToAction("companies", "cargocompany", new { area = "admin" });
    }
    [Route("deletecompany/{id}")]
    public async Task<IActionResult> DeleteCompany(int id)
    {
        await _companyService.DeleteCompanyAsync(id);
        return RedirectToAction("companies", "cargocompany", new { area = "admin" });
    }
    [HttpGet]
    [Route("updatecompany/{id}")]
    public async Task<IActionResult> UpdateCompany(int id)
    {
        GetCompanyViewbagList();
        ViewBag.v3 = "Kargo Şirketi Güncelleme Sayfası";
        UpdateCompanyDto? value = await _companyService.GetCompanyForUpdateAsync(id);
        return View(value);
    }
    [HttpPost]
    [Route("updatecompany/{id}")]
    public async Task<IActionResult> UpdateCompany(UpdateCompanyDto updateCompanyDto)
    {
        await _companyService.UpdateCompanyAsync(updateCompanyDto);
        return RedirectToAction("companies", "cargocompany", new { area = "admin" });
    }

    private void GetCompanyViewbagList()
    {
        ViewBag.v1 = "Anasayfa";
        ViewBag.v2 = "Kargo İşlemleri";
    }
}
