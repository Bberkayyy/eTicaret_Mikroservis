using e_Ticaret.WebUIDtos.CatalogDtos.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace e_Ticaret.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/contact")]
public class ContactController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ContactController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [Route("index")]
    public async Task<IActionResult> Index()
    {
        GetContactViewbagList();
        ViewBag.v3 = "Mesaj Listesi";
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/contacts");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IEnumerable<ResultContactDto>? values = JsonConvert.DeserializeObject<IEnumerable<ResultContactDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [Route("detail/{id}")]
    public async Task<IActionResult> ContactDetail(string id)
    {
        GetContactViewbagList();
        ViewBag.v3 = "Mesaj Detayı";
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/contacts/" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            ResultContactDto? value = JsonConvert.DeserializeObject<ResultContactDto>(jsonData);
            return View(value);
        }
        return View();
    }
    [Route("deletecontact/{id}")]
    public async Task<IActionResult> DeleteContact(string id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync("https://localhost:7070/api/contacts?id=" + id);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("index", "contact", new { area = "admin" });
        return View();
    }
    [Route("isreadtotrue/{id}")]
    public async Task<IActionResult> ChangeIsReadToTrue(string id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7070/api/contacts/isreadtotrue?id=" + id);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("index", "contact", new { area = "admin" });
        return View();
    }
    private void GetContactViewbagList()
    {
        ViewBag.v1 = "Anasayfa";
        ViewBag.v2 = "İletişim İşlemleri";
    }
}
