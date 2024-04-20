using e_Ticaret.WebUIDtos.CatalogDtos.SpecialOfferDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace e_Ticaret.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/specialoffer")]
public class SpecialOfferController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public SpecialOfferController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [Route("index")]
    public async Task<IActionResult> Index()
    {
        GetSpecialOfferViewbagList();
        ViewBag.v3 = "Özel Teklif Listesi";
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/specialoffers");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IEnumerable<ResultSpecialOfferDto>? values = JsonConvert.DeserializeObject<IEnumerable<ResultSpecialOfferDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("createspecialoffer")]
    public IActionResult CreateSpecialOffer()
    {
        GetSpecialOfferViewbagList();
        ViewBag.v3 = "Özel Teklif Ekleme Sayfası";
        return View();
    }
    [HttpPost]
    [Route("createspecialoffer")]
    public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createSpecialOfferDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:7070/api/specialoffers", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("index", "specialoffer", new { area = "admin" });
        return View();
    }
    [Route("deletespecialoffer/{id}")]
    public async Task<IActionResult> DeleteSpecialOffer(string id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync("https://localhost:7070/api/specialoffers?id=" + id);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("index", "specialoffer", new { area = "admin" });
        return View();
    }
    [HttpGet]
    [Route("updatespecialoffer/{id}")]
    public async Task<IActionResult> UpdateSpecialOffer(string id)
    {
        GetSpecialOfferViewbagList();
        ViewBag.v3 = "Özel Teklif Güncelleme Sayfası";
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/specialoffers/" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            UpdateSpecialOfferDto? value = JsonConvert.DeserializeObject<UpdateSpecialOfferDto>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("updatespecialoffer/{id}")]
    public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(updateSpecialOfferDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("https://localhost:7070/api/specialoffers", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("index", "specialoffer", new { area = "admin" });
        return View();
    }
    private void GetSpecialOfferViewbagList()
    {
        ViewBag.v1 = "Anasayfa";
        ViewBag.v2 = "Özel Teklif İşlemleri";
    }
}
