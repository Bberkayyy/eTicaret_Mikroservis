using e_Ticaret.WebUI.Services.CatalogServices.ContactServices;
using e_Ticaret.WebUIDtos.CatalogDtos.ContactDtos;
using e_Ticaret.WebUIDtos.CommentDtos.UserCommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace e_Ticaret.WebUI.Controllers;

public class ContactController : Controller
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet]
    public IActionResult Index() { return View(); }
    [HttpPost]
    public async Task<IActionResult> Index(CreateContactDto createContactDto)
    {
        await _contactService.CreateContactAsync(createContactDto);
        return RedirectToAction("Index", "contact");
    }
}
