using e_Ticaret.Catalog.Dtos.ContactDtos;
using e_Ticaret.Catalog.Services.ContactServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.Catalog.Controllers;

[Route("api/contacts")]
[ApiController]
public class ContactsController : ControllerBase
{
    private readonly IContactService _contactService;

    public ContactsController(IContactService ContactService)
    {
        _contactService = ContactService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<GetAllContactResponseDto> values = await _contactService.GetAllContactAsync();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetContact(string id)
    {
        GetContactResponseDto value = await _contactService.GetContactAsync(id);
        return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> CreateContact(CreateContactRequestDto createContactRequestDto)
    {
        await _contactService.CreateContactAsync(createContactRequestDto);
        return Ok("Mesaj başarıyla eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteContact(string id)
    {
        await _contactService.DeleteContactAsync(id);
        return Ok("Mesaj başarıyla silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateContact(UpdateContactRequestDto updateContactRequestDto)
    {
        await _contactService.UpdateContactAsync(updateContactRequestDto);
        return Ok("Mesaj başarıyla güncellendi.");
    }
    [HttpGet("isreadtotrue")]
    public async Task<IActionResult> ChangeIsReadToTrue(string id)
    {
        _contactService.ChangeIsReadToTrue(id);
        return Ok("Mesaj okundu olarak işaretlendi.");
    }
}
