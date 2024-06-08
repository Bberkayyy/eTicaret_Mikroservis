using e_Ticaret.WebUI.Models;
using e_Ticaret.WebUI.Services.Abstract;
using e_Ticaret.WebUI.Services.OrderServices.AddressServices;
using e_Ticaret.WebUIDtos.OrderDtos.AddressDtos;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.Controllers;

public class OrderController : Controller
{
    private readonly IAddressService _addressService;
    private readonly IUserService _userService;

    public OrderController(IAddressService addressService, IUserService userService)
    {
        _addressService = addressService;
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(CreateAddressDto createAddressDto)
    {
        UserDetailViewModel user = await _userService.GetUserInfo();
        createAddressDto.UserId = user.Id;
        await _addressService.CreateAddressAsync(createAddressDto);
        return RedirectToAction("index", "payment");
    }

}
