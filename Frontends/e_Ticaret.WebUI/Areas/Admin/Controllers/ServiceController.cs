using e_Ticaret.WebUIDtos.CatalogDtos.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace e_Ticaret.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/service")]
public class ServiceController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ServiceController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [Route("index")]
    public async Task<IActionResult> Index()
    {
        GetServiceViewbagList();
        ViewBag.v3 = "Hizmet Listesi";
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/services");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IEnumerable<ResultServiceDto>? values = JsonConvert.DeserializeObject<IEnumerable<ResultServiceDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("createservice")]
    public IActionResult CreateService()
    {
        GetServiceViewbagList();
        ViewBag.v3 = "Hizmet Ekleme Sayfası";
        return View();
    }
    [HttpPost]
    [Route("createservice")]
    public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createServiceDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:7070/api/services", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("index", "service", new { area = "admin" });
        return View();
    }
    [Route("deleteservice/{id}")]
    public async Task<IActionResult> DeleteService(string id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync("https://localhost:7070/api/services?id=" + id);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("index", "service", new { area = "admin" });
        return View();
    }
    [HttpGet]
    [Route("updateservice/{id}")]
    public async Task<IActionResult> UpdateService(string id)
    {
        GetServiceViewbagList();
        ViewBag.v3 = "Hizmet Güncelleme Sayfası";
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/services/" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            UpdateServiceDto? value = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("updateservice/{id}")]
    public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(updateServiceDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("https://localhost:7070/api/services", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("index", "service", new { area = "admin" });
        return View();
    }
    private void GetServiceViewbagList()
    {
        ViewBag.v1 = "Anasayfa";
        ViewBag.v2 = "Hizmet İşlemleri";
    }
}
