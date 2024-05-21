using e_Ticaret.IdentityServer.Dtos;
using e_Ticaret.IdentityServer.Models;
using e_Ticaret.IdentityServer.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace e_Ticaret.IdentityServer.Controllers;

[AllowAnonymous]
[Route("api/logins")]
[ApiController]
public class LoginsController : ControllerBase
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public LoginsController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> UserLogin(UserLoginDto userLoginDto)
    {
        ApplicationUser user = await _userManager.FindByNameAsync(userLoginDto.Username);
        var result = await _signInManager.PasswordSignInAsync(userLoginDto.Username, userLoginDto.Password, false, true);
        if (result.Succeeded)
        {
            GetCheckAppUserViewModel getCheckAppUserViewModel = new GetCheckAppUserViewModel();
            getCheckAppUserViewModel.Username = userLoginDto.Username;
            getCheckAppUserViewModel.Id = user.Id;
            TokenResponseViewModel token = JwtTokenGenerator.GenerateToken(getCheckAppUserViewModel);
            return Ok(token);
        }
        else { return Ok("Kullanıcı adı veya şifre yanlış!"); }

    }
}
