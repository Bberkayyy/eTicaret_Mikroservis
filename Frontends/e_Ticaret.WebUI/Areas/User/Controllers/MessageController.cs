using e_Ticaret.WebUI.Models;
using e_Ticaret.WebUI.Services.Abstract;
using e_Ticaret.WebUI.Services.MessageServices;
using e_Ticaret.WebUIDtos.MessageDtos;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.Areas.User.Controllers;

[Area("User")]
public class MessageController : Controller
{
    private readonly IMessageService _messageService;
    private readonly IUserService _userService;

    public MessageController(IMessageService messageService, IUserService userService)
    {
        _messageService = messageService;
        _userService = userService;
    }

    public async Task<IActionResult> Inbox()
    {
        UserDetailViewModel user = await _userService.GetUserInfo();
        List<ResultMessageInboxDto> values = await _messageService.GetMessageInboxAsync(user.Id);
        return View(values);
    }
    public async Task<IActionResult> Sendbox()
    {
        UserDetailViewModel user = await _userService.GetUserInfo();
        List<ResultMessageSendboxDto> values = await _messageService.GetMessageSendboxAsync(user.Id);
        return View(values);
    }
}
