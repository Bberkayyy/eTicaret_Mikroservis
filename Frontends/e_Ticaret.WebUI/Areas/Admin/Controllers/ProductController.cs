using e_Ticaret.WebUI.Services.CatalogServices.CategoryServices;
using e_Ticaret.WebUI.Services.CatalogServices.ProductServices;
using e_Ticaret.WebUIDtos.CatalogDtos.CategoryDtos;
using e_Ticaret.WebUIDtos.CatalogDtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace e_Ticaret.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/product")]
public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public ProductController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }
    [Route("index")]
    public async Task<IActionResult> Index()
    {
        GetProductViewbagList();
        ViewBag.v3 = "Ürün Listesi";
        IEnumerable<ResultProductWithRelationshipsDto>? values = await _productService.GetAllProductWithRelationshipsAsync();
        return View(values);
    }
    [HttpGet]
    [Route("createproduct")]
    public async Task<IActionResult> CreateProduct()
    {
        GetProductViewbagList();
        ViewBag.categoryList = await GetCategoryList();
        ViewBag.v3 = "Ürün Ekleme Sayfası";
        return View();
    }
    [HttpPost]
    [Route("createproduct")]
    public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
    {
        await _productService.CreateProductAsync(createProductDto);
        return RedirectToAction("index", "product", new { area = "Admin" });
    }
    [Route("deleteproduct/{id}")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        await _productService.DeleteProductAsync(id);
        return RedirectToAction("index", "product", new { area = "admin" });
    }
    [HttpGet]
    [Route("updateproduct/{id}")]
    public async Task<IActionResult> UpdateProduct(string id)
    {
        GetProductViewbagList();
        ViewBag.categoriesForUpdate = await GetCategoryList();
        ViewBag.v3 = "Ürün Güncelleme Sayfası";
        UpdateProductDto? value = await _productService.GetProductForUpdateAsync(id);
        return View(value);

    }
    [HttpPost]
    [Route("updateproduct/{id}")]
    public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
    {
        await _productService.UpdateProductAsync(updateProductDto);
        return RedirectToAction("index", "product", new { area = "admin" });
    }
    private void GetProductViewbagList()
    {
        ViewBag.v1 = "Anasayfa";
        ViewBag.v2 = "Ürün İşlemleri";
    }
    private async Task<IEnumerable<SelectListItem>> GetCategoryList()
    {
        IEnumerable<ResultCategoryDto>? categories = await _categoryService.GetAllCategoryAsync();
        IEnumerable<SelectListItem>? values = categories.Select(x => new SelectListItem
        {
            Text = x.Name,
            Value = x.Id
        }).ToList();
        return values;
    }
}
