namespace e_Ticaret.WebUI.Services.Abstract;

public interface IClientCredentialTokenService
{
    Task<string> GetToken();
}
