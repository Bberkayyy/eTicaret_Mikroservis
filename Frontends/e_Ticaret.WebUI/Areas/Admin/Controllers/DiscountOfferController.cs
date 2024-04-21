using e_Ticaret.WebUIDtos.CatalogDtos.DiscountOfferDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace e_Ticaret.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/discountoffer")]
public class DiscountOfferController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DiscountOfferController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [Route("index")]
    public async Task<IActionResult> Index()
    {
        GetDiscountOfferViewbagList();
        ViewBag.v3 = "İndirim Teklifi Listesi";
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/discountoffers");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IEnumerable<ResultDiscountOfferDto>? values = JsonConvert.DeserializeObject<IEnumerable<ResultDiscountOfferDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("creatediscountoffer")]
    public IActionResult CreateDiscountOffer()
    {
        GetDiscountOfferViewbagList();
        ViewBag.v3 = "İndirim Teklifi Ekleme Sayfası";
        return View();
    }
    [HttpPost]
    [Route("creatediscountoffer")]
    public async Task<IActionResult> CreateDiscountOffer(CreateDiscountOfferDto createDiscountOfferDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createDiscountOfferDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:7070/api/discountoffers", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("index", "discountoffer", new { area = "Admin" });
        return View();
    }
    [Route("deletediscountoffer/{id}")]
    public async Task<IActionResult> DeleteDiscountOffer(string id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync("https://localhost:7070/api/discountoffers?id=" + id);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("index", "discountoffer", new { area = "admin" });
        return View();
    }
    [HttpGet]
    [Route("updatediscountoffer/{id}")]
    public async Task<IActionResult> UpdateDiscountOffer(string id)
    {
        GetDiscountOfferViewbagList();
        ViewBag.v3 = "İndirim Teklifi Güncelleme Sayfası";
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/discountoffers/" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            UpdateDiscountOfferDto? value = JsonConvert.DeserializeObject<UpdateDiscountOfferDto>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("updatediscountoffer/{id}")]
    public async Task<IActionResult> UpdateDiscountOffer(UpdateDiscountOfferDto updateDiscountOfferDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(updateDiscountOfferDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("https://localhost:7070/api/discountoffers", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("index", "discountoffer", new { area = "admin" });
        return View();
    }
    private void GetDiscountOfferViewbagList()
    {
        ViewBag.v1 = "Anasayfa";
        ViewBag.v2 = "İndirim Teklifi İşlemleri";
    }
}
