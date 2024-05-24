using e_Ticaret.WebUI.Services.CatalogServices.CategoryServices;
using e_Ticaret.WebUI.Services.CatalogServices.ProductServices;
using e_Ticaret.WebUIDtos.CatalogDtos.CategoryDtos;
using e_Ticaret.WebUIDtos.CatalogDtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace e_Ticaret.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/category")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;

    public CategoryController(ICategoryService categoryService, IProductService productService)
    {
        _categoryService = categoryService;
        _productService = productService;
    }
    [Route("index")]
    public async Task<IActionResult> Index()
    {
        GetCategoryViewbagList();
        ViewBag.v3 = "Kategori Listesi";
        IEnumerable<ResultCategoryDto> values = await _categoryService.GetAllCategoryAsync();
        return View(values);
    }
    [Route("categoryproducts")]
    public async Task<IActionResult> CategoryProducts(string categoryId)
    {
        GetCategoryViewbagList();
        ViewBag.categoryName = await GetCategoryName(categoryId);
        ViewBag.v3 = $"{await GetCategoryName(categoryId)} Kategorisine Ait Ürün Listesi";

        IEnumerable<ResultProductWithRelationshipsByCategoryIdDto>? values = await _productService.GetAllProductWithRelationshipsByCategoryIdAsync(categoryId);
        return View(values);
    }
    [HttpGet]
    [Route("createcategory")]
    public IActionResult CreateCategory()
    {
        GetCategoryViewbagList();
        ViewBag.v3 = "Kategori Ekleme Sayfası";
        return View();
    }
    [HttpPost]
    [Route("createcategory")]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
    {
        await _categoryService.CreateCategoryAsync(createCategoryDto);
        return RedirectToAction("index", "category", new { area = "Admin" });

    }
    [Route("deletecategory/{id}")]
    public async Task<IActionResult> DeleteCategory(string id)
    {
        await _categoryService.DeleteCategoryAsync(id);
        return RedirectToAction("index", "category", new { area = "admin" });
    }
    [HttpGet]
    [Route("updatecategory/{id}")]
    public async Task<IActionResult> UpdateCategory(string id)
    {
        GetCategoryViewbagList();
        ViewBag.v3 = "Kategori Güncelleme Sayfası";
        UpdateCategoryDto value = await _categoryService.GetCategoryForUpdateAsync(id);
        return View(value);
    }
    [HttpPost]
    [Route("updatecategory/{id}")]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
    {
        await _categoryService.UpdateCategoryAsync(updateCategoryDto);
        return RedirectToAction("index", "category", new { area = "admin" });
    }
    private void GetCategoryViewbagList()
    {
        ViewBag.v1 = "Anasayfa";
        ViewBag.v2 = "Kategori İşlemleri";
    }
    private async Task<string> GetCategoryName(string id)
    {
        GetCategoryByIdDto value = await _categoryService.GetCategoryById(id);
        return value.Name;
    }
}
