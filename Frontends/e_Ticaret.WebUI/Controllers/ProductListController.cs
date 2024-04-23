using e_Ticaret.WebUIDtos.CatalogDtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace e_Ticaret.WebUI.Controllers;

public class ProductListController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ProductListController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public IActionResult ProductList()
    {
        return View();
    }
    public IActionResult ProductDetail()
    {
        return View();
    }
    public async Task<IActionResult> ProductListByCategory(string id)
    {
        ViewBag.Id = id;
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/categories/" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            ResultCategoryDto? value = JsonConvert.DeserializeObject<ResultCategoryDto>(jsonData);
            ViewBag.categoryName = value.Name;
        }
        return View();
    }
}
