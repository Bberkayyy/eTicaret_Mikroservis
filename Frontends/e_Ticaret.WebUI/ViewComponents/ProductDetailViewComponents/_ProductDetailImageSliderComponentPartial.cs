using e_Ticaret.WebUI.Services.CatalogServices.ProductImageServices;
using e_Ticaret.WebUIDtos.CatalogDtos.ProductImageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace e_Ticaret.WebUI.ViewComponents.ProductDetailViewComponents;

public class _ProductDetailImageSliderComponentPartial : ViewComponent
{
    private readonly IProductImageService _productImageService;

    public _ProductDetailImageSliderComponentPartial(IProductImageService productImageService)
    {
        _productImageService = productImageService;
    }

    public async Task<IViewComponentResult> InvokeAsync(string productId)
    {
        ResultProductImageWithRelationshipsByProductIdDto? value = await _productImageService.GetProductImageWithRelationshipsByProductIdAsync(productId);
        return View(value);
    }
}
