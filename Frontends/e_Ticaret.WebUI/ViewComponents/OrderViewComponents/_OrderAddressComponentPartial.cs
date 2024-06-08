using e_Ticaret.WebUI.Models;
using e_Ticaret.WebUI.Services.Abstract;
using e_Ticaret.WebUI.Services.OrderServices.AddressServices;
using e_Ticaret.WebUIDtos.OrderDtos.AddressDtos;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.WebUI.ViewComponents.OrderViewComponents;

public class _OrderAddressComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() { return View(); }
}
