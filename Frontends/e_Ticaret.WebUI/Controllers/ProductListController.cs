using e_Ticaret.WebUIDtos.CatalogDtos.CategoryDtos;
using e_Ticaret.WebUIDtos.CommentDtos.UserCommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

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
    public IActionResult ProductDetail(string id)
    {
        ViewBag.productId = id;
        return View();
    }
    public async Task<IActionResult> ProductListByCategory(string id)
    {
        ViewBag.categoryId = id;
        ViewBag.categoryName = await GetCategoryName(id);
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> AddComment(CreateUserCommentDto createUserCommentDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createUserCommentDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:7075/api/comments", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("productdetail", "productlist", new { id = createUserCommentDto.ProductId });
        return View();
    }
    private async Task<string> GetCategoryName(string id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/categories/" + id);
        string jsonData = await responseMessage.Content.ReadAsStringAsync();
        ResultCategoryDto? value = JsonConvert.DeserializeObject<ResultCategoryDto>(jsonData);
        return value.Name;
    }
}
