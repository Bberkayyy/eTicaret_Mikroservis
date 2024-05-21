using System.Security.Claims;
using e_Ticaret.WebUI.Services.Abstract;

namespace e_Ticaret.WebUI.Services.Concrete;

public class LoginService : ILoginService
{
    private readonly IHttpContextAccessor _contextAccessor;

    public LoginService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public string GetUserId => _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
}
