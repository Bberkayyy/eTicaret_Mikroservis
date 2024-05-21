using e_Ticaret.IdentityServer.Dtos;
using e_Ticaret.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace e_Ticaret.IdentityServer.Controllers;

[AllowAnonymous]
[Route("api/registers")]
[ApiController]
public class RegistersController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    public RegistersController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    [HttpPost]
    public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
    {
        ApplicationUser value = new()
        {
            Email = userRegisterDto.Email,
            UserName = userRegisterDto.Username,
            Name = userRegisterDto.Name,
            Surname = userRegisterDto.Surname,
        };
        IdentityResult result = await _userManager.CreateAsync(value, userRegisterDto.Password);
        if (result.Succeeded)
            return Ok("Kullanıcı başarıla eklendi.");
        else
            return Ok("Kullanıcı oluşturulurken bir hata oluştu!");
    }
}
