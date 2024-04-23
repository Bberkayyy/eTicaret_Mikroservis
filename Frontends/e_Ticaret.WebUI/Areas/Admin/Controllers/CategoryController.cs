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
    private readonly IHttpClientFactory _httpClientFactory;

    public CategoryController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [Route("index")]
    public async Task<IActionResult> Index()
    {
        GetCategoryViewbagList();
        ViewBag.v3 = "Kategori Listesi";
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/categories");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IEnumerable<ResultCategoryDto>? values = JsonConvert.DeserializeObject<IEnumerable<ResultCategoryDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [Route("categoryproducts")]
    public async Task<IActionResult> CategoryProducts(string categoryId)
    {
        GetCategoryViewbagList();
        ViewBag.categoryName = await GetCategoryName(categoryId);
        ViewBag.v3 = $"{await GetCategoryName(categoryId)} Kategorisine Ait Ürün Listesi";
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/products/withrelationshipsbycategoryid?categoryId=" + categoryId);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IEnumerable<ResultProductWithRelationshipsByCategoryIdDto>? values = JsonConvert.DeserializeObject<IEnumerable<ResultProductWithRelationshipsByCategoryIdDto>>(jsonData);
            return View(values);
        }
        return View();
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
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createCategoryDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:7070/api/categories", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("index", "category", new { area = "Admin" });
        return View();
    }
    [Route("deletecategory/{id}")]
    public async Task<IActionResult> DeleteCategory(string id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync("https://localhost:7070/api/categories?id=" + id);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("index", "category", new { area = "admin" });
        return View();
    }
    [HttpGet]
    [Route("updatecategory/{id}")]
    public async Task<IActionResult> UpdateCategory(string id)
    {
        GetCategoryViewbagList();
        ViewBag.v3 = "Kategori Güncelleme Sayfası";
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/categories/" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            UpdateCategoryDto? value = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("updatecategory/{id}")]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(updateCategoryDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("https://localhost:7070/api/categories", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("index", "category", new { area = "admin" });
        return View();
    }
    private void GetCategoryViewbagList()
    {
        ViewBag.v1 = "Anasayfa";
        ViewBag.v2 = "Kategori İşlemleri";
    }
    private async Task<string> GetCategoryName(string id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/categories/" + id);
        string jsonData = await responseMessage.Content.ReadAsStringAsync();
        JObject value = JObject.Parse(jsonData);
        string categoryName = (string)value["name"];
        return categoryName;
    }
}
