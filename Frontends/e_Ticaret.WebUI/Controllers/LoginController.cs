using e_Ticaret.WebUI.Models;
using e_Ticaret.WebUI.Services.Abstract;
using e_Ticaret.WebUIDtos.IdentityDtos.LoginDtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace e_Ticaret.WebUI.Controllers;

public class LoginController : Controller
{
    private readonly IIdentityService _identityService;

    public LoginController(IIdentityService identityService)
    {
        _identityService = identityService;
    }
    [HttpGet]
    public IActionResult LoginForm()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> LoginForm(SignInDto signInDto)
    {
        await _identityService.SignIn(signInDto);
        return RedirectToAction("Index", "MainPage");
    }
}

