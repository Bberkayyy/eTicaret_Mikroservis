using e_Ticaret.WebUI.Services.CatalogServices.CategoryServices;
using e_Ticaret.WebUI.Services.CommentServices.UserCommentServices;
using e_Ticaret.WebUIDtos.CatalogDtos.CategoryDtos;
using e_Ticaret.WebUIDtos.CommentDtos.UserCommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace e_Ticaret.WebUI.Controllers;

public class ProductListController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly IUserCommentService _userCommentService;

    public ProductListController(ICategoryService categoryService, IUserCommentService userCommentService)
    {
        _categoryService = categoryService;
        _userCommentService = userCommentService;
    }

    public IActionResult ProductList()
    {
        return View();
    }
    public IActionResult ProductDetail(string id)
    {
        ViewBag.productId = id;
        return View();
    }
    public async Task<IActionResult> ProductListByCategory(string id)
    {
        ViewBag.categoryId = id;
        ViewBag.categoryName = await GetCategoryName(id);
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> AddComment(CreateUserCommentDto createUserCommentDto)
    {
        await _userCommentService.CreateUserCommentAsync(createUserCommentDto);
        return RedirectToAction("productdetail", "productlist", new { id = createUserCommentDto.ProductId });
    }
    private async Task<string> GetCategoryName(string id)
    {
        GetCategoryByIdDto? value = await _categoryService.GetCategoryById(id);
        return value.Name;
    }
}
