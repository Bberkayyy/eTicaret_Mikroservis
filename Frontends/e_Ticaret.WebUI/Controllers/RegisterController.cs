using e_Ticaret.WebUI.Services.IdentityServices;
using e_Ticaret.WebUIDtos.IdentityDtos.RegisterDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace e_Ticaret.WebUI.Controllers;

public class RegisterController : Controller
{
    private readonly IRegisterService _registerService;

    public RegisterController(IRegisterService registerService)
    {
        _registerService = registerService;
    }
    [HttpGet]
    public IActionResult RegisterForm()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> RegisterForm(CreateRegisterDto createRegisterDto)
    {
        if (createRegisterDto.Password == createRegisterDto.ConfirmPassword)
        {
            await _registerService.SignUp(createRegisterDto);
            return RedirectToAction("LoginForm", "Login");
        }
        return View();
    }
}
