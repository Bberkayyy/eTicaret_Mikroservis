using e_Ticaret.WebUI.Services.CatalogServices.ProductServices;
using e_Ticaret.WebUI.Services.CatalogServices.UserCommentServices;
using e_Ticaret.WebUIDtos.CatalogDtos.ProductDtos;
using e_Ticaret.WebUIDtos.CommentDtos.UserCommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace e_Ticaret.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/usercomment")]
public class UserCommentController : Controller
{
    private readonly IUserCommentService _userCommentService;
    private readonly IProductService _productService;

    public UserCommentController(IUserCommentService userCommentService, IProductService productService)
    {
        _userCommentService = userCommentService;
        _productService = productService;
    }

    [Route("index")]
    public async Task<IActionResult> Index()
    {
        GetUserCommentViewbagList();
        ViewBag.v3 = "Yorum Listesi";
        IEnumerable<ResultUserCommentDto>? values = await _userCommentService.GetAllUserCommentAsync();
        return View(values);
    }
    [Route("comment/{productId}")]
    public async Task<IActionResult> Comments(string productId)
    {
        ViewBag.v1 = "Anasayfa";
        ViewBag.v2 = "Ürün İşlemleri";
        string productName = await GetProductName(productId);
        ViewBag.productName = productName;
        ViewBag.productId = productId;
        ViewBag.v3 = $"{productName} Ürününe Ait Yorumlar"; ;
        IEnumerable<ResultUserCommentDto>? values = await _userCommentService.GetUserCommentsByProductIdAsync(productId);
        return View(values);
    }
    [Route("deleteusercomment/{id}")]
    public async Task<IActionResult> DeleteUserComment(string id)
    {
        await _userCommentService.DeleteUserCommentAsync(id);
        return RedirectToAction("index", "usercomment", new { area = "admin" });
    }
    [HttpGet]
    [Route("updateusercomment/{id}")]
    public async Task<IActionResult> UpdateUserComment(string id)
    {
        GetUserCommentViewbagList();
        ViewBag.v3 = "Yorum Güncelleme Sayfası";
        UpdateUserCommentDto? value = await _userCommentService.GetUserCommentForUpdateAsync(id);
        return View(value);
    }
    [HttpPost]
    [Route("updateusercomment/{id}")]
    public async Task<IActionResult> UpdateUserComment(UpdateUserCommentDto updateUserCommentDto)
    {
        await _userCommentService.UpdateUserCommentAsync(updateUserCommentDto);
        return RedirectToAction("index", "usercomment", new { area = "admin" });
    }
    private void GetUserCommentViewbagList()
    {
        ViewBag.v1 = "Anasayfa";
        ViewBag.v2 = "Yorum İşlemleri";
    }
    private async Task<string> GetProductName(string id)
    {
        GetProductByIdDto? value = await _productService.GetProductByIdAsync(id);
        return value.Name;
    }
}
