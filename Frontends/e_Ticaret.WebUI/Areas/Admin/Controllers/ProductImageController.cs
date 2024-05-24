using e_Ticaret.WebUI.Services.CatalogServices.ProductImageServices;
using e_Ticaret.WebUI.Services.CatalogServices.ProductServices;
using e_Ticaret.WebUIDtos.CatalogDtos.ProductDtos;
using e_Ticaret.WebUIDtos.CatalogDtos.ProductImageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace e_Ticaret.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/productimage")]
public class ProductImageController : Controller
{
    private readonly IProductImageService _productImageService;
    private readonly IProductService _productService;

    public ProductImageController(IProductImageService productImageService, IProductService productService)
    {
        _productImageService = productImageService;
        _productService = productService;
    }

    [Route("images/{productId}")]
    public async Task<IActionResult> Images(string productId)
    {
        GetProductImageViewbagList();
        ViewBag.productName = await GetProductName(productId);
        ViewBag.productId = productId;
        ResultProductImageWithRelationshipsByProductIdDto? value = await _productImageService.GetProductImageWithRelationshipsByProductIdAsync(productId);
        ViewBag.v3 = $"{value.ProductName} Ürününe Ait Görseller";
        return View(value);
    }
    [HttpGet]
    [Route("createimages/{productId}")]
    public async Task<IActionResult> CreateProductImage(string productId)
    {
        GetProductImageViewbagList();
        ViewBag.productId = productId;
        ViewBag.productName = await GetProductName(productId);
        ViewBag.v3 = "Ürün Görseli Ekleme Sayfası";
        return View();
    }
    [HttpPost]
    [Route("createimages/{productId}")]
    public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
    {
        await _productImageService.CreateProductImageAsync(createProductImageDto);
        return RedirectToAction("images", "productimage", new { area = "admin", productId = createProductImageDto.ProductId });
    }
    [Route("deleteimages/{id}")]
    public async Task<IActionResult> DeleteProductImage(string id)
    {
        await _productImageService.DeleteProductImageAsync(id);
        return RedirectToAction("index", "product", new { area = "admin" });
    }
    [HttpGet]
    [Route("updateimages/{id}")]
    public async Task<IActionResult> UpdateProductImage(string id)
    {
        GetProductImageViewbagList();
        ViewBag.v3 = "Ürün Görseli Güncelleme Sayfası";
        UpdateProductImageDto? value = await _productImageService.GetProductImageForUpdateAsync(id);
        ViewBag.productIdForUpdate = value.ProductId;
        ViewBag.productNameForUpdate = await GetProductName(value.ProductId);
        return View(value);
    }
    [HttpPost]
    [Route("updateimages/{id}")]
    public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
    {
        await _productImageService.UpdateProductImageAsync(updateProductImageDto);
        return RedirectToAction("images", "productimage", new { area = "admin", productId = updateProductImageDto.ProductId });
    }
    private void GetProductImageViewbagList()
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
