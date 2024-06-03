using e_Ticaret.WebUIDtos.IdentityDtos.RegisterDtos;

namespace e_Ticaret.WebUI.Services.IdentityServices;

public interface IRegisterService
{
    Task SignUp(CreateRegisterDto createRegisterDto);
}
