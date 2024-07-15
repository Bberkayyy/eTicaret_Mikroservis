using e_Ticaret.IdentityServer.Dtos;
using e_Ticaret.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace e_Ticaret.IdentityServer.Controllers;

[Authorize(LocalApi.PolicyName)]
[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UsersController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet("getuserinfo")]
    public async Task<IActionResult> GetUserInfo()
    {
        Claim userClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
        ApplicationUser user = await _userManager.FindByIdAsync(userClaim.Value);
        return Ok(new
        {
            Id = user.Id,
            Name = user.Name,
            Surname = user.Surname,
            Email = user.Email,
            Username = user.UserName
        });
    }
    [HttpGet("getallusers")]
    public async Task<IActionResult> GetAllUsers()
    {
        List<ApplicationUser> users = await _userManager.Users.ToListAsync();
        List<GetAllUsersResponseDto> response = users.Select(x => GetAllUsersResponseDto.ConvertToResponse(x)).ToList();
        return Ok(response);
    }
}
