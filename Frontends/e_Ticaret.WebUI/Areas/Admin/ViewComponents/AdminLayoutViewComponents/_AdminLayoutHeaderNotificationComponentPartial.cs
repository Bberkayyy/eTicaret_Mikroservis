using e_Ticaret.WebUI.Services.StatisticServices.CommentStatisticServices;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents;

public class _AdminLayoutHeaderNotificationComponentPartial : ViewComponent
{
    private readonly ICommentStatisticService _commentStatisticService;

    public _AdminLayoutHeaderNotificationComponentPartial(ICommentStatisticService commentStatisticService)
    {
        _commentStatisticService = commentStatisticService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        ViewBag.commentCount = await _commentStatisticService.GetCommentCount();
        return View();
    }
}
