using e_Ticaret.IdentityServer.Dtos;
using e_Ticaret.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace e_Ticaret.IdentityServer.Controllers;

[Authorize(LocalApi.PolicyName)]
[Route("api/statistics")]
[ApiController]
public class StatisticsController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    public StatisticsController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    [HttpGet("getusercount")]
    public async Task<IActionResult> GetAllUsers()
    {
        int userCount = await _userManager.Users.CountAsync();
        return Ok(userCount);
    }
}
