using e_Ticaret.WebUI.Services.CatalogServices.ProductServices;
using e_Ticaret.WebUIDtos.CatalogDtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace e_Ticaret.WebUI.ViewComponents.ProductListViewComponents;

public class _ProductListComponentPartial : ViewComponent
{
    private readonly IProductService _productService;

    public _ProductListComponentPartial(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        IEnumerable<ResultProductDto>? values = await _productService.GetAllProductAsync();
        return View(values);
    }
}
