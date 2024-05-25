using e_Ticaret.WebUI.Services.CommentServices.UserCommentServices;
using e_Ticaret.WebUIDtos.CommentDtos.UserCommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace e_Ticaret.WebUI.ViewComponents.ProductDetailViewComponents;

public class _ProductDetailReviewComponentPartial : ViewComponent
{
    private readonly IUserCommentService _userCommentService;

    public _ProductDetailReviewComponentPartial(IUserCommentService userCommentService)
    {
        _userCommentService = userCommentService;
    }

    public async Task<IViewComponentResult> InvokeAsync(string productId)
    {
        ViewBag.productId = productId;
        IEnumerable<ResultUserCommentDto>? values = await _userCommentService.GetUserCommentsByProductIdAsync(productId);
        return View(values);
    }
}
