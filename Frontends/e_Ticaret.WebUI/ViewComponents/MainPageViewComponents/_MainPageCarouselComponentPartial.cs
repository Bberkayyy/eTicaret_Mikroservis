using e_Ticaret.WebUI.Services.CatalogServices.FeatureSliderServices;
using e_Ticaret.WebUIDtos.CatalogDtos.FeatureSliderDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace e_Ticaret.WebUI.ViewComponents.MainPageViewComponents;

public class _MainPageCarouselComponentPartial : ViewComponent
{
    private readonly IFeatureSliderService _featureSliderService;

    public _MainPageCarouselComponentPartial(IFeatureSliderService featureSliderService)
    {
        _featureSliderService = featureSliderService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        IEnumerable<ResultFeatureSliderDto>? values = await _featureSliderService.GetAllFeatureSliderAsync();
        return View(values);
    }
}
