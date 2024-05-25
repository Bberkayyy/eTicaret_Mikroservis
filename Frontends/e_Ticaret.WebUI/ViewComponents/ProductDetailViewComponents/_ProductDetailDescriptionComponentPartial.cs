using e_Ticaret.WebUI.Services.CatalogServices.ProductDetailServices;
using e_Ticaret.WebUIDtos.CatalogDtos.ProductDetailDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace e_Ticaret.WebUI.ViewComponents.ProductDetailViewComponents;

public class _ProductDetailDescriptionComponentPartial : ViewComponent
{
    private readonly IProductDetailService _productDetailService;

    public _ProductDetailDescriptionComponentPartial(IProductDetailService productDetailService)
    {
        _productDetailService = productDetailService;
    }

    public async Task<IViewComponentResult> InvokeAsync(string productId)
    {
        ResultProductDetailWithRelationshipsByProductIdDto? value = await _productDetailService.GetProductDetailWithRelationshipsByProductIdAsync(productId);
        return View(value);
    }
}
