using e_Ticaret.WebUI.Services.CatalogServices.ServiceServices;
using e_Ticaret.WebUIDtos.CatalogDtos.FeatureSliderDtos;
using e_Ticaret.WebUIDtos.CatalogDtos.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace e_Ticaret.WebUI.ViewComponents.MainPageViewComponents;

public class _MainPageServicesComponentPartial : ViewComponent
{
    private readonly IServiceService _serviceService;

    public _MainPageServicesComponentPartial(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        IEnumerable<ResultServiceDto>? values = await _serviceService.GetAllServiceAsync();
        return View(values);
    }
}
