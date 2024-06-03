using e_Ticaret.WebUIDtos.IdentityDtos.RegisterDtos;

namespace e_Ticaret.WebUI.Services.IdentityServices;

public class RegisterService : IRegisterService
{
    private readonly HttpClient _httpClient;

    public RegisterService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task SignUp(CreateRegisterDto createRegisterDto)
    {
        await _httpClient.PostAsJsonAsync("api/registers", createRegisterDto);
    }
}
