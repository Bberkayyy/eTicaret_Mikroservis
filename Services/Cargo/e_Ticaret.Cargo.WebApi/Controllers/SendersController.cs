using e_Ticaret.Cargo.BusinessLayer.Abstract;
using e_Ticaret.Cargo.DtoLayer.ApiDtos.SenderDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.Cargo.WebApi.Controllers;

[Authorize]
[Route("api/senders")]
[ApiController]
public class SendersController : ControllerBase
{
    private readonly ISenderService _senderService;

    public SendersController(ISenderService SenderService)
    {
        _senderService = SenderService;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        IEnumerable<GetAllSenderResponseDto> values = _senderService.TGetAll();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        GetSenderByIdResponseDto value = _senderService.TGetById(id);
        return Ok(value);
    }
    [HttpPost]
    public IActionResult CreateSender(CreateSenderRequestDto createSenderRequestDto)
    {
        _senderService.TAdd(createSenderRequestDto);
        return Ok("Kargo gönderen müşteri başarıyla eklendi.");
    }
    [HttpDelete]
    public IActionResult DeleteSender(int id)
    {
        _senderService.TDelete(id);
        return Ok("Kargo gönderen müşteri başarıyla silindi.");
    }
    [HttpPut]
    public IActionResult UpdateSender(UpdateSenderRequestDto updateSenderRequestDto)
    {
        _senderService.TUpdate(updateSenderRequestDto);
        return Ok("Kargo gönderen müşteri başarıyla güncellendi.");
    }
}
