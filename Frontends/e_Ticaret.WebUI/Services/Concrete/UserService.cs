using e_Ticaret.WebUI.Models;
using e_Ticaret.WebUI.Services.Abstract;

namespace e_Ticaret.WebUI.Services.Concrete;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<UserDetailViewModel> GetUserInfo()
    {
        return await _httpClient.GetFromJsonAsync<UserDetailViewModel>("/api/users/getuserinfo");
    }
}
