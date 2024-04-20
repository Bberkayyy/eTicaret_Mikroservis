using e_Ticaret.WebUIDtos.CatalogDtos.FeatureSliderDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace e_Ticaret.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/featureslider")]
public class FeatureSliderController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public FeatureSliderController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [Route("index")]
    public async Task<IActionResult> Index()
    {
        GetFeatureSliderViewbagList();
        ViewBag.v3 = "Öne Çıkan Görsel Listesi";
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/featuresliders");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IEnumerable<ResultFeatureSliderDto>? values = JsonConvert.DeserializeObject<IEnumerable<ResultFeatureSliderDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("createfeatureslider")]
    public IActionResult CreateFeatureSlider()
    {
        GetFeatureSliderViewbagList();
        ViewBag.v3 = "Öne Çıkan Görsel Sayfası";
        return View();
    }
    [HttpPost]
    [Route("createfeatureslider")]
    public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createFeatureSliderDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:7070/api/featuresliders", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("index", "featureslider", new { area = "Admin" });
        return View();
    }
    [Route("deletefeatureslider/{id}")]
    public async Task<IActionResult> DeleteFeatureSlider(string id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync("https://localhost:7070/api/featuresliders?id=" + id);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("index", "featureslider", new { area = "admin" });
        return View();
    }
    [HttpGet]
    [Route("updatefeatureslider/{id}")]
    public async Task<IActionResult> UpdateFeatureSlider(string id)
    {
        GetFeatureSliderViewbagList();
        ViewBag.v3 = "Öne Çıkan Görsel Güncelleme Sayfası";
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/featuresliders/" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            UpdateFeatureSliderDto? value = JsonConvert.DeserializeObject<UpdateFeatureSliderDto>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("updatefeatureslider/{id}")]
    public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(updateFeatureSliderDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("https://localhost:7070/api/featuresliders", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("index", "featureslider", new { area = "admin" });
        return View();
    }
    private void GetFeatureSliderViewbagList()
    {
        ViewBag.v1 = "Anasayfa";
        ViewBag.v2 = "Öne Çıkan Görsel İşlemleri";
    }
}
