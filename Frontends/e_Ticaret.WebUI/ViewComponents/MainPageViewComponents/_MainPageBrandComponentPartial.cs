using e_Ticaret.WebUI.Services.CatalogServices.BrandServices;
using e_Ticaret.WebUIDtos.CatalogDtos.BrandDtos;
using e_Ticaret.WebUIDtos.CatalogDtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace e_Ticaret.WebUI.ViewComponents.MainPageViewComponents;

public class _MainPageBrandComponentPartial : ViewComponent
{
    private readonly IBrandService _brandService;

    public _MainPageBrandComponentPartial(IBrandService brandService)
    {
        _brandService = brandService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        IEnumerable<ResultBrandDto>? values = await _brandService.GetAllBrandAsync();
        return View(values);
    }
}
