using e_Ticaret.WebUI.Services.CatalogServices.AboutServices;
using e_Ticaret.WebUIDtos.CatalogDtos.AboutDtos;
using e_Ticaret.WebUIDtos.CatalogDtos.BrandDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace e_Ticaret.WebUI.ViewComponents.UILayoutViewComponents;

public class _UILayoutFooterAboutComponentPartial : ViewComponent
{
    private readonly IAboutService _aboutService;

    public _UILayoutFooterAboutComponentPartial(IAboutService aboutService)
    {
        _aboutService = aboutService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        IEnumerable<ResultAboutDto>? values = await _aboutService.GetAllAboutAsync();
        return View(values);
    }
}
