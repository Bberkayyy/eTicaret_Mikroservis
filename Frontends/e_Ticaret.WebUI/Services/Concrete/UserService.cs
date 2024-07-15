using e_Ticaret.WebUI.Models;
using e_Ticaret.WebUI.Services.Abstract;
using e_Ticaret.WebUIDtos.IdentityDtos.UserDtos;

namespace e_Ticaret.WebUI.Services.Concrete;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ResultUserDto>> GetAllUsersAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<ResultUserDto>>("/api/users/getallusers");
    }

    public async Task<UserDetailViewModel> GetUserInfo()
    {
        return await _httpClient.GetFromJsonAsync<UserDetailViewModel>("/api/users/getuserinfo");
    }
}
