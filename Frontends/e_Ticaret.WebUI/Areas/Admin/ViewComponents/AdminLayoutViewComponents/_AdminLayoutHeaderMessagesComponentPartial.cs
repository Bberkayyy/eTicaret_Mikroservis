using e_Ticaret.WebUI.Models;
using e_Ticaret.WebUI.Services.Abstract;
using e_Ticaret.WebUI.Services.StatisticServices.MessageStatisticServices;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents;

public class _AdminLayoutHeaderMessagesComponentPartial : ViewComponent
{
    private readonly IMessageStatisticService _messageStatisticService;
    private readonly IUserService _userService;

    public _AdminLayoutHeaderMessagesComponentPartial(IMessageStatisticService messageService, IUserService userService)
    {
        _messageStatisticService = messageService;
        _userService = userService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        UserDetailViewModel user = await _userService.GetUserInfo();
        ViewBag.incomingMessages = await _messageStatisticService.GetNumberOfIncomingMessage(user.Id);
        return View();
    }
}
