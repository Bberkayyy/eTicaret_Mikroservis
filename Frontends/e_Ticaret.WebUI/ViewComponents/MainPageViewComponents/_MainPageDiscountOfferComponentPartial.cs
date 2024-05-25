using e_Ticaret.WebUI.Services.CatalogServices.DiscountOfferServices;
using e_Ticaret.WebUIDtos.CatalogDtos.CategoryDtos;
using e_Ticaret.WebUIDtos.CatalogDtos.DiscountOfferDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace e_Ticaret.WebUI.ViewComponents.MainPageViewComponents;

public class _MainPageDiscountOfferComponentPartial : ViewComponent
{
    private readonly IDiscountOfferService _discountOfferService;

    public _MainPageDiscountOfferComponentPartial(IDiscountOfferService discountOfferService)
    {
        _discountOfferService = discountOfferService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        IEnumerable<ResultDiscountOfferDto>? values = await _discountOfferService.GetAllDiscountOfferAsync();
        return View(values);
    }
}
