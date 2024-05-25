using e_Ticaret.WebUI.Services.CatalogServices.ProductServices;
using e_Ticaret.WebUIDtos.CatalogDtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace e_Ticaret.WebUI.ViewComponents.ProductDetailViewComponents;

public class _ProductDetailFeatureComponentPartial : ViewComponent
{
    private readonly IProductService _productService;

    public _ProductDetailFeatureComponentPartial(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IViewComponentResult> InvokeAsync(string productId)
    {
        GetProductByIdDto? value = await _productService.GetProductByIdAsync(productId);
        return View(value);
    }
}
