using e_Ticaret.WebUI.Models;
using e_Ticaret.WebUI.Services.Abstract;
using e_Ticaret.WebUI.Services.OrderServices.OrderingServices;
using e_Ticaret.WebUIDtos.OrderDtos.OrderingDtos;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.Areas.User.Controllers;

[Area("User")]
public class OrderController : Controller
{
    private readonly IOrderingService _orderingService;
    private readonly IUserService _userService;

    public OrderController(IOrderingService orderingService, IUserService userService)
    {
        _orderingService = orderingService;
        _userService = userService;
    }

    public async Task<IActionResult> MyOrderList()
    {
        UserDetailViewModel user = await _userService.GetUserInfo();
        List<ResultOrderingDto> values = await _orderingService.GetOrderingByUserIdAsync(user.Id);
        return View(values);
    }
}
