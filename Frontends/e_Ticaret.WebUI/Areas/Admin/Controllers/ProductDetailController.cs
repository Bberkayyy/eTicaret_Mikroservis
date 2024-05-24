using e_Ticaret.WebUI.Services.CatalogServices.ProductDetailServices;
using e_Ticaret.WebUI.Services.CatalogServices.ProductServices;
using e_Ticaret.WebUIDtos.CatalogDtos.ProductDetailDtos;
using e_Ticaret.WebUIDtos.CatalogDtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace e_Ticaret.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/productdetail")]
public class ProductDetailController : Controller
{
    private readonly IProductDetailService _productDetailService;
    private readonly IProductService _productService;

    public ProductDetailController(IProductDetailService productDetailService, IProductService productService)
    {
        _productDetailService = productDetailService;
        _productService = productService;
    }

    [Route("details/{productId}")]
    public async Task<IActionResult> Details(string productId)
    {
        GetProductDetailViewbagList();
        ViewBag.productName = await GetProductName(productId);
        ViewBag.productId = productId;
        ResultProductDetailWithRelationshipsByProductIdDto? value = await _productDetailService.GetProductDetailWithRelationshipsByProductIdAsync(productId);
        ViewBag.v3 = $"{value.ProductName} Ürününe Ait Açıklama ve Bilgi";
        return View(value);
    }
    [HttpGet]
    [Route("createdetails/{productId}")]
    public async Task<IActionResult> CreateProductDetail(string productId)
    {
        GetProductDetailViewbagList();
        ViewBag.productId = productId;
        ViewBag.productName = await GetProductName(productId);
        ViewBag.v3 = "Ürün Açıklama ve Bilgi Ekleme Sayfası";
        return View();
    }
    [HttpPost]
    [Route("createdetails/{productId}")]
    public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
    {
        await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
        return RedirectToAction("details", "productdetail", new { area = "admin", productId = createProductDetailDto.ProductId });
    }
    [Route("deletedetails/{id}")]
    public async Task<IActionResult> DeleteProductDetail(string id)
    {
        await _productDetailService.DeleteProductDetailAsync(id);
        return RedirectToAction("index", "product", new { area = "admin" });
    }
    [HttpGet]
    [Route("updatedetails/{id}")]
    public async Task<IActionResult> UpdateProductDetail(string id)
    {
        GetProductDetailViewbagList();
        ViewBag.v3 = "Ürün Açıklama ve Bilgi Güncelleme Sayfası";
        UpdateProductDetailDto? value = await _productDetailService.GetProductDetailForUpdateAsync(id);
        ViewBag.productIdForUpdate = value.ProductId;
        ViewBag.productNameForUpdate = await GetProductName(value.ProductId);
        return View(value);
    }
    [HttpPost]
    [Route("updatedetails/{id}")]
    public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
    {
        await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
        return RedirectToAction("details", "productdetail", new { area = "admin", productId = updateProductDetailDto.ProductId });
    }
    private void GetProductDetailViewbagList()
    {
        ViewBag.v1 = "Anasayfa";
        ViewBag.v2 = "Ürün İşlemleri";
    }
    private async Task<string> GetProductName(string id)
    {
        GetProductByIdDto? value = await _productService.GetProductByIdAsync(id);
        return value.Name;
    }
}
