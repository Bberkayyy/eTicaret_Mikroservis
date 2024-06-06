using e_Ticaret.WebUI.Services.BasketServices;
using e_Ticaret.WebUI.Services.CatalogServices.ProductServices;
using e_Ticaret.WebUIDtos.BasketDtos;
using e_Ticaret.WebUIDtos.CatalogDtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.Controllers;

public class ShoppingCartController : Controller
{
    private readonly IBasketService _basketService;
    private readonly IProductService _productService;

    public ShoppingCartController(IBasketService basketService, IProductService productService)
    {
        _basketService = basketService;
        _productService = productService;
    }

    public IActionResult ShoppingCart(int couponRate)
    {
        ViewBag.CouponRate = couponRate;
        return View();
    }
    public async Task<IActionResult> AddToBasket(string id)
    {
        GetProductByIdDto product = await _productService.GetProductByIdAsync(id);
        var items = new BasketItemsDto
        {
            ProductId = product.Id,
            ProductName = product.Name,
            ProductImageUrl = product.ImageUrl,
            UnitPrice = product.Price,
            Quantity = 1
        };
        await _basketService.AddBasketItem(items);
        return RedirectToAction("ShoppingCart");
    }
    public async Task<IActionResult> RemoveFromBasket(string id)
    {
        await _basketService.RemoveBasketItem(id);
        return RedirectToAction("ShoppingCart");
    }
}
