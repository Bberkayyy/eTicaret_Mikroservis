using e_Ticaret.WebUIDtos.IdentityDtos.RegisterDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace e_Ticaret.WebUI.Controllers;

public class RegisterController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public RegisterController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
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
            HttpClient client = _httpClientFactory.CreateClient();
            string jsonData = JsonConvert.SerializeObject(createRegisterDto);
            StringContent content = new(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync("http://localhost:5001/api/registers", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("LoginForm", "Login");
            }
        }
        return View();
    }
}
