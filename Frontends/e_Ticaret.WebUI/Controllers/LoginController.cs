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
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILoginService _loginService;

    public LoginController(IHttpClientFactory httpClientFactory, ILoginService loginService)
    {
        _httpClientFactory = httpClientFactory;
        _loginService = loginService;
    }
    [HttpGet]
    public IActionResult LoginForm()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> LoginForm(CreateLoginDto createLoginDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonSerializer.Serialize(createLoginDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("http://localhost:5001/api/logins", content);
        if (responseMessage.IsSuccessStatusCode)
        {
            string data = await responseMessage.Content.ReadAsStringAsync();
            JwtResponseModel? tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(data, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            if (tokenModel != null)
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken token = tokenHandler.ReadJwtToken(tokenModel.Token);
                List<Claim> claims = token.Claims.ToList();

                claims.Add(new Claim("e_ticaretjwt", tokenModel.Token));
                ClaimsIdentity claimsIdentity = new(claims, JwtBearerDefaults.AuthenticationScheme);
                AuthenticationProperties authProps = new()
                {
                    ExpiresUtc = tokenModel.ExpireDate,
                    IsPersistent = true
                };
                await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                return RedirectToAction("Index", "MainPage");
            }
        }
        return View();
    }
}

