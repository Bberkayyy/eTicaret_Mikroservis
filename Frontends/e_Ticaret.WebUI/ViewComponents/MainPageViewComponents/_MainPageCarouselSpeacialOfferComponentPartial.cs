using e_Ticaret.WebUI.Services.CatalogServices.SpecialOfferServices;
using e_Ticaret.WebUIDtos.CatalogDtos.FeatureSliderDtos;
using e_Ticaret.WebUIDtos.CatalogDtos.SpecialOfferDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace e_Ticaret.WebUI.ViewComponents.MainPageViewComponents;

public class _MainPageCarouselSpeacialOfferComponentPartial : ViewComponent
{
    private readonly ISpecialOfferService _specialOfferService;

    public _MainPageCarouselSpeacialOfferComponentPartial(ISpecialOfferService specialOfferService)
    {
        _specialOfferService = specialOfferService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        IEnumerable<ResultSpecialOfferDto>? values = await _specialOfferService.GetAllSpecialOfferAsync();
        return View(values);
    }
}
