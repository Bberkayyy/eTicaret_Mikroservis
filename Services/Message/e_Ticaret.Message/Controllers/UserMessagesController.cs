using e_Ticaret.Message.Dtos;
using e_Ticaret.Message.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.Message.Controllers;

[Route("api/usermessages")]
[ApiController]
public class UserMessagesController : ControllerBase
{
    private readonly IUserMessageService _userMessageService;

    public UserMessagesController(IUserMessageService userMessageService)
    {
        _userMessageService = userMessageService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMessage()
    {
        List<GetAllMessageResponseDto> values = await _userMessageService.GetAllMessageAsync();
        return Ok(values);
    }
    [HttpGet("getsendbox/{senderId}")]
    public async Task<IActionResult> GetMessageSendbox(string senderId)
    {
        List<ResultMessageSendboxResponseDto> values = await _userMessageService.GetMessageSendboxAsync(senderId);
        return Ok(values);
    }
    [HttpGet("getinbox/{receiverId}")]
    public async Task<IActionResult> GetMessageInbox(string receiverId)
    {
        List<ResultMessageInboxResponseDto> values = await _userMessageService.GetMessageInboxAsync(receiverId);
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetMessageById(int id)
    {
        GetMessageByIdResponseDto value = await _userMessageService.GetMessageByIdAsync(id);
        return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> CreateMessage(CreateMessageRequestDto createMessageRequestDto)
    {
        await _userMessageService.CreateMessageAsync(createMessageRequestDto);
        return Ok("Mesaj başarıyla gönderildi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteMessage(int id)
    {
        await _userMessageService.DeleteMessageAsync(id);
        return Ok("Mesaj başarıyla silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateMessage(UpdateMessageRequestDto updateMessageRequestDto)
    {
        await _userMessageService.UpdateMessageAsync(updateMessageRequestDto);
        return Ok("Mesaj başarıyla güncellendi.");
    }
}
