using e_Ticaret.WebUIDtos.IdentityDtos.LoginDtos;

namespace e_Ticaret.WebUI.Services.Abstract;

public interface IIdentityService
{
    Task<bool> SignIn(SignInDto signInDto);
}
