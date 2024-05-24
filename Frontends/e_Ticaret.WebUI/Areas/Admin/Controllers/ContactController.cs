using e_Ticaret.WebUI.Services.CatalogServices.ContactServices;
using e_Ticaret.WebUIDtos.CatalogDtos.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace e_Ticaret.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/contact")]
public class ContactController : Controller
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [Route("index")]
    public async Task<IActionResult> Index()
    {
        GetContactViewbagList();
        ViewBag.v3 = "Mesaj Listesi";
        IEnumerable<ResultContactDto>? values = await _contactService.GetAllContactAsync();
        return View(values);
    }
    [Route("detail/{id}")]
    public async Task<IActionResult> ContactDetail(string id)
    {
        GetContactViewbagList();
        ViewBag.v3 = "Mesaj Detayı";
        ResultContactDto? value = await _contactService.GetContactForDetailAsync(id);
        return View(value);
    }
    [Route("deletecontact/{id}")]
    public async Task<IActionResult> DeleteContact(string id)
    {
        await _contactService.DeleteContactAsync(id);
        return RedirectToAction("index", "contact", new { area = "admin" });
    }
    [Route("isreadtotrue/{id}")]
    public async Task<IActionResult> ChangeIsReadToTrue(string id)
    {
        await _contactService.ChangeIsReadToTrueAsync(id);
        return RedirectToAction("index", "contact", new { area = "admin" });
    }
    private void GetContactViewbagList()
    {
        ViewBag.v1 = "Anasayfa";
        ViewBag.v2 = "İletişim İşlemleri";
    }
}
