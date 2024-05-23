using e_Ticaret.WebUI.Models;

namespace e_Ticaret.WebUI.Services.Abstract;

public interface IUserService
{
    Task<UserDetailViewModel> GetUserInfo();
}
