using e_Ticaret.WebUI.Models;
using e_Ticaret.WebUIDtos.IdentityDtos.UserDtos;

namespace e_Ticaret.WebUI.Services.Abstract;

public interface IUserService
{
    Task<UserDetailViewModel> GetUserInfo();
    Task<List<ResultUserDto>> GetAllUsersAsync();
}
