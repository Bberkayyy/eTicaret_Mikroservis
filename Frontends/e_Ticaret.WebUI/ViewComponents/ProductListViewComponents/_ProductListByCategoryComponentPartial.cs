using e_Ticaret.WebUI.Services.CatalogServices.ProductServices;
using e_Ticaret.WebUIDtos.CatalogDtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace e_Ticaret.WebUI.ViewComponents.ProductListViewComponents;

public class _ProductListByCategoryComponentPartial : ViewComponent
{
    private readonly IProductService _productService;

    public _ProductListByCategoryComponentPartial(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IViewComponentResult> InvokeAsync(string categoryId)
    {
        IEnumerable<ResultProductWithRelationshipsByCategoryIdDto>? values = await _productService.GetAllProductWithRelationshipsByCategoryIdAsync(categoryId);
        return View(values);
    }
}
