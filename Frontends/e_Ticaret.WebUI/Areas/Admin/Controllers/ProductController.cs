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
    private readonly IHttpClientFactory _httpClientFactory;

    public ProductController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [Route("index")]
    public async Task<IActionResult> Index()
    {
        GetProductViewbagList();
        ViewBag.v3 = "Ürün Listesi";
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/products/withrelationships");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IEnumerable<ResultProductWithRelationshipsDto>? values = JsonConvert.DeserializeObject<IEnumerable<ResultProductWithRelationshipsDto>>(jsonData);
            return View(values);
        }
        return View();
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
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createProductDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:7070/api/products", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("index", "product", new { area = "Admin" });
        return View();
    }
    [Route("deleteproduct/{id}")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync("https://localhost:7070/api/products?id=" + id);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("index", "product", new { area = "admin" });
        return View();
    }
    [HttpGet]
    [Route("updateproduct/{id}")]
    public async Task<IActionResult> UpdateProduct(string id)
    {
        GetProductViewbagList();
        ViewBag.categoriesForUpdate = await GetCategoryList();
        ViewBag.v3 = "Ürün Güncelleme Sayfası";
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/products/" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            UpdateProductDto? value = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("updateproduct/{id}")]
    public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(updateProductDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("https://localhost:7070/api/products", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("index", "product", new { area = "admin" });
        return View();
    }
    private void GetProductViewbagList()
    {
        ViewBag.v1 = "Anasayfa";
        ViewBag.v2 = "Ürün İşlemleri";
    }
    private async Task<IEnumerable<SelectListItem>> GetCategoryList()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage resposeMessage = await client.GetAsync("https://localhost:7070/api/categories");
        string jsonData = await resposeMessage.Content.ReadAsStringAsync();
        IEnumerable<ResultCategoryDto>? categories = JsonConvert.DeserializeObject<IEnumerable<ResultCategoryDto>>(jsonData);
        IEnumerable<SelectListItem>? values = categories.Select(x => new SelectListItem
        {
            Text = x.Name,
            Value = x.Id
        }).ToList();
        return values;
    }
}
