using e_Ticaret.WebUIDtos.CatalogDtos.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace e_Ticaret.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/about")]
public class AboutController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AboutController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [Route("index")]
    public async Task<IActionResult> Index()
    {
        GetAboutViewbagList();
        ViewBag.v3 = "Hakkımızda Listesi";
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/abouts");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IEnumerable<ResultAboutDto>? values = JsonConvert.DeserializeObject<IEnumerable<ResultAboutDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("createabout")]
    public IActionResult CreateAbout()
    {
        GetAboutViewbagList();
        ViewBag.v3 = "Hakkımızda Ekleme Sayfası";
        return View();
    }
    [HttpPost]
    [Route("createabout")]
    public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createAboutDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:7070/api/abouts", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("index", "about", new { area = "admin" });
        return View();
    }
    [Route("deleteabout/{id}")]
    public async Task<IActionResult> DeleteAbout(string id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync("https://localhost:7070/api/abouts?id=" + id);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("index", "about", new { area = "admin" });
        return View();
    }
    [HttpGet]
    [Route("updateabout/{id}")]
    public async Task<IActionResult> UpdateAbout(string id)
    {
        GetAboutViewbagList();
        ViewBag.v3 = "Hakkımızda Güncelleme Sayfası";
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/abouts/" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            UpdateAboutDto? value = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("updateabout/{id}")]
    public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(updateAboutDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("https://localhost:7070/api/abouts", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("index", "about", new { area = "admin" });
        return View();
    }
    private void GetAboutViewbagList()
    {
        ViewBag.v1 = "Anasayfa";
        ViewBag.v2 = "Hakkımızda İşlemleri";
    }
}
