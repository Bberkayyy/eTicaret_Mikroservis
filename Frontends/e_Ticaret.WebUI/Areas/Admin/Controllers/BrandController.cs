using e_Ticaret.WebUIDtos.CatalogDtos.BrandDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace e_Ticaret.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/brand")]
public class BrandController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BrandController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [Route("index")]
    public async Task<IActionResult> Index()
    {
        GetBrandViewbagList();
        ViewBag.v3 = "Marka Listesi";
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/brands");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IEnumerable<ResultBrandDto>? values = JsonConvert.DeserializeObject<IEnumerable<ResultBrandDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("createbrand")]
    public IActionResult CreateBrand()
    {
        GetBrandViewbagList();
        ViewBag.v3 = "Marka Ekleme Sayfası";
        return View();
    }
    [HttpPost]
    [Route("createbrand")]
    public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createBrandDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:7070/api/brands", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("index", "brand", new { area = "admin" });
        return View();
    }
    [Route("deletebrand/{id}")]
    public async Task<IActionResult> DeleteBrand(string id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync("https://localhost:7070/api/brands?id=" + id);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("index", "brand", new { area = "admin" });
        return View();
    }
    [HttpGet]
    [Route("updatebrand/{id}")]
    public async Task<IActionResult> UpdateBrand(string id)
    {
        GetBrandViewbagList();
        ViewBag.v3 = "Marka Güncelleme Sayfası";
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/brands/" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            UpdateBrandDto? value = JsonConvert.DeserializeObject<UpdateBrandDto>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("updatebrand/{id}")]
    public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(updateBrandDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("https://localhost:7070/api/brands", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("index", "brand", new { area = "admin" });
        return View();
    }
    private void GetBrandViewbagList()
    {
        ViewBag.v1 = "Anasayfa";
        ViewBag.v2 = "Marka İşlemleri";
    }
}
